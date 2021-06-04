using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaptchaMvc.HtmlHelpers;
using CommonProject;
using Model;
using Model.Common;
using Model.Dao;
using Model.ModelCustom;
using Model.Services;

namespace QuizOnlineDeveloper.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(UserLoginCustom model, string returnUrl)
        {
            var userCookies = new StoredCookies();
            var userLoginCustom = (UserLoginCustom)userCookies.GetInfoUserCookies(model.UserName, model.Password, model.RememberMe);
            model.UserName = userLoginCustom.UserName;
            model.Password = userLoginCustom.Password;
            model.RememberMe = userLoginCustom.RememberMe;
            model.returnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserLoginCustom model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var userService = new UserServices();
                var result = userService.Login(model);
                if (result)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    var user = dao.GetUserByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.UserID;
                    Session.Add(new CommonConstant().USER_SESSION, userSession);
                    var sess = (UserLogin)Session[new CommonConstant().USER_SESSION];

                    //FormsAuthentication.SetAuthCookie(model.UserName, false);

                    // Response.Cookies.Add(new System.Web.HttpCookie("CookieThanhDM3", model.UserName)
                    // {
                    //     Expires = DateTime.Now.AddDays(3),
                    //     HttpOnly = true
                    // });

                    var userCookies = new StoredCookies();
                    if (model.RememberMe == true)
                    {
                        userCookies.NewInfoUserCookies(model.UserName, model.Password);
                    }
                    else
                    {
                        userCookies.DeleteInfoUserCookies();
                    }
                    var role = new UserRole().GetRolesForUser(model.UserName);
                    for (int i = 0; i < role.Length; i++)
                    {
                        if (role[i] == "Admin")
                        {
                            return RedirectToAction("Index", "Home", new { Area = "Admin" });
                        }
                        else if (returnUrl == "" || role[i] == "User")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    
                    //else
                    //{
                    //    var builder = new UriBuilder(Request.Url.Scheme, Request.Url.Host, Request.Url.Port);
                    //    var builderPath = builder + returnUrl.Substring(1);
                    //    return Redirect(builderPath);
                    //}

                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
                }
            }
            return View("Index", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            // Set cookie với thời gian Expires đã hết hạn
            // Brower tự xóa cookie
            //Response.Cookies.Add(new System.Web.HttpCookie("userName", "") { Expires = DateTime.Now.AddDays(-1) });
            //Response.Cookies.Add(new System.Web.HttpCookie("password", "") { Expires = DateTime.Now.AddDays(-1) });
            var userCookies = new StoredCookies();
            userCookies.DeleteInfoUserCookies();
            Session[new CommonConstant().USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(string Email)
        {
            if (Email == "")
            {
                ModelState.AddModelError("", "Vui lòng nhập địa chỉ mail.");
                ViewBag.Error = "error";
            }
            else if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!dao.checkEmail(Email))
                {
                    ModelState.AddModelError("", "Địa chỉ mail không đúng.");
                    ViewBag.Error = "error";
                }
                else if (!this.IsCaptchaValid(errorText: ""))
                {
                    ModelState.AddModelError("", "Bạn đã nhập sai mã captcha.");
                    ViewBag.Error = "error";
                }
                else
                {
                    var result = dao.GetUserIDbyEmail(Email);

                    if (result > 0)
                    {
                        string resetcode = Guid.NewGuid().ToString();
                        dao.addResetCode(resetcode, Email);
                        sendEmailResetPass(resetcode, Email);
                        ViewBag.Success = "Vui lòng kiểm tra hộp thư mail để thay đổi mật khẩu.";
                        ViewBag.Error = null;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Địa chỉ mail không đúng.");
                        ViewBag.Error = "error";
                    }
                }
            }
            else
            {
                ViewBag.Error = "error";
            }
            return View();
        }
        public ActionResult ConfirmResetPassword(string id)
        {
            var dao = new UserDao();
            var result = dao.checkCodeReset(id);
            if (result)
            {
                ResetPasswordUser model = new ResetPasswordUser();
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult ConfirmResetPassword(ResetPasswordUser model)
        {
            if (ModelState.IsValid)
            {

                var user = new UserDao();
                var resutlt = user.resetPassword(model.ResetCode, Encryptor.MD5Hash(model.NewPassword));
                ViewBag.Error = null;
                ViewBag.Success = "Bạn đã thay đổi mật khẩu thành công! Bây giờ bạn có thể đăng nhập :";
                if (resutlt == false)
                {
                    ViewBag.Error = "error";
                }
            }
            else
            {
                ViewBag.Error = "error";
            }
            return View(model);
        }
        public void sendEmailResetPass(string code, string email)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Asserts/Client/template/ResetPassword.html"));
            var url = "https://localhost:44374/" + "Login/ConfirmResetPassword/" + code;
            content = content.Replace("{{url}}", url);
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            new MailHelper().SendMail(email, "Reset mật khẩu", content, "Thay đổi mật khẩu của bạn tại Academy");
        }


    }
}