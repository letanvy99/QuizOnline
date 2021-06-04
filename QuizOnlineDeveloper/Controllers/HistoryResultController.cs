using Model.Dao;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class HistoryResultController : BaseController
    {
        [ActionName("HistoryResult")]
        public ActionResult Index(ExamCustom exam)
        {
            if (TempData["modelExam"] != null)
            {
                ExamCustom std = (ExamCustom)TempData["modelExam"];
                exam = std;
            }
            var sess = (Model.Common.UserLogin)Session[new Model.Common.CommonConstant().USER_SESSION];
            var userAlredyDoQuiz = sess.UserID;
            var userClassExamID = new ExamDao().getUserClassExamID(exam.UserID, exam.ClassExamID);
            var test = new ExamDao().GetListResult(userClassExamID);
            return View(test);
        }


        //tai thay doi db. ti sua

        //public ActionResult Details(long id)
        //{
        //    ViewBag.CountWrong = new ExamDao().countWrongAnswer(id);
        //    ViewBag.CountRight = new ExamDao().countRightAnswer(id);
        //    var Details = new ExamDao().GetDetailResuilt(id);
        //    ViewBag.GetuserclassexamID = id;
        //    return View(Details);
        //}

    }
}