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
        public ActionResult ShowInfo(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id, string commentlock)
        {

            var result = new UserDao().ChangeStatus(id, commentlock);
            return Json(new
            {
                status = result
            });
        }
    }
}