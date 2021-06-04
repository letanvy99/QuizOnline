using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Areas.Admin.Controllers
{
    public class ManagerUserController : Controller
    {
        // GET: Admin/ManagerUser
        public ActionResult Index()
        {
            var dao = new UserDao();
            var user = dao.listAllUser();
            return View(user);
        }
    }
}