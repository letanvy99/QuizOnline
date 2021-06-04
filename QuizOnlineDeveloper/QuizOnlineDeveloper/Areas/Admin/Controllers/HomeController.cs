using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var userdao = new UserDao();
            var classdao = new ClassDao();
            var categarydao = new CategoryDao();
            var examdao = new ExamDao();
            ViewBag.countUser = userdao.countUser();
            ViewBag.countClass = classdao.countClass();
            ViewBag.countCategory = categarydao.countCategory();
            ViewBag.countExam = examdao.countExams();
            return View();
        }
    }
}