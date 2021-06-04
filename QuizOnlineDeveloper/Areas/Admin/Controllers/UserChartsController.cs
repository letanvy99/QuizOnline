using Model.Dao;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Areas.Admin.Controllers
{
    public class UserChartsController : Controller
    {
        // GET: Admin/UserCharts
        public ActionResult Index()
        {
            List<UserCharts> userCharts = new List<UserCharts>();
            var dao = new UserDao();
            var date = DateTime.Now;
            userCharts.Add(new UserCharts(date.AddDays(-10).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-10))));
            userCharts.Add(new UserCharts(date.AddDays(-9).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-9))));
            userCharts.Add(new UserCharts(date.AddDays(-8).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-8))));
            userCharts.Add(new UserCharts(date.AddDays(-7).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-7))));
            userCharts.Add(new UserCharts(date.AddDays(-6).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-6))));
            userCharts.Add(new UserCharts(date.AddDays(-5).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-5))));
            userCharts.Add(new UserCharts(date.AddDays(-4).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-4))));
            userCharts.Add(new UserCharts(date.AddDays(-3).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-3))));
            userCharts.Add(new UserCharts(date.AddDays(-2).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-2))));
            userCharts.Add(new UserCharts(date.AddDays(-1).ToString("dd/MM/yyyy"), dao.countUserbyDay(date.AddDays(-1))));
            ViewBag.maxValue = userCharts.Max(x => x.countRegister);
            ViewBag.CountRegister = dao.ConvertToJSON(userCharts);
            return View();
        }
    }
}