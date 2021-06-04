using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Dao;
using Model.ModelCustom;
using Model.Services;

namespace QuizOnlineDeveloper.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(UserLoginCustom model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var userService = new UserServices(); 
                var result = userService.Login(model);
                if (result)
                {
                    var user = dao.GetUserByID(model.UserName);
                    var userSession = new Model.Common.UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.UserID;
                    userSession.Role = user.Role;
                    Session.Add(Model.Common.CommonConstant.USER_SESSION,userSession);
                    var sess = (Model.Common.UserLogin)Session[Model.Common.CommonConstant.USER_SESSION];
                    if(sess.Role == 0)
                    {
                        // chuyển sang Admin
                        // đây chỉ viết ví dụ, có thể return View().... or ReturnRedirect
                        //return Content("haha xin chao admin");
                        return RedirectToAction("Index", "TestLoginAdmin");
                    }
                    else
                    {
                        // chuyển sang User
                        return Content("haha xin chao user");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
                }
            }
            return View();
            //return RedirectToAction("Index", "Home");
        }
    }
}