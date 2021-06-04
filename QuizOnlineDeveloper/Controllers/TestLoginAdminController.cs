using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class TestLoginAdminController : Controller
    {
        // GET: TestLoginAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test(ExamCustom model)
        {
            return View(model);
        }
    }
}