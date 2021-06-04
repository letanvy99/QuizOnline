using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Infrastructure;
using CommonProject;
using Model.Common;
using Model.Dao;
using Model.EF;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.checkUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                    ViewBag.Error = "error";
                }
                if (dao.checkEmail(model.Email))
                {
                    ModelState.AddModelError("", "Địa chỉ mail đã đăng kí trên hệ thống.");
                    ViewBag.Error = "error";
                }
                if (!this.IsCaptchaValid(errorText: ""))
                {
                    ModelState.AddModelError("", "Bạn đã nhập sai mã captcha.");
                    ViewBag.Error = "error";
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.Email = model.Email;
                    user.Online = false;
                    user.CreateAt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    user.LockStatus = false;
                    var result = dao.InsertUser(user);
                    dao.addUserRole(result, 2);

                    if (result > 0)
                    {
                        string code = Guid.NewGuid().ToString();
                        dao.addActiveCode(code, model.UserName);
                        sendEmailRegister(code, model.Email);
                        ViewBag.Success = "Đăng kí thành công. Vui lòng kiểm tra mail để xác nhận tài khoản";
                        ViewBag.Error = null;
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công. Địa chỉ mail không tồn tại !");
                        ViewBag.Error = "error";
                    }
                }
            }
            else
            {
                ViewBag.Error = "error";
            }
            return View(model);
        }
        public ActionResult Confirm(string id)
        {
            var dao = new UserDao();
            dao.ValidateEmail(id);
            return View();
        }
        public void sendEmailRegister(string code, string email)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Asserts/Client/template/ConfirmRegister.html"));
            var url = "https://localhost:44374/" + "Register/Confirm/" + code;
            content = content.Replace("{{url}}", url);
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            new MailHelper().SendMail(email, "Xác nhận tài khoản tại Academy", content, "Xác nhận tài khoản");
        }
    }
}