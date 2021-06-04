using Model.Common;
using Model.Dao;
using Model.EF;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class ExamController : BaseController
    {
        // GET: Exam
        [Authorize(Roles = "Admin, User")]
        [ActionName("List")]
        [HttpGet]
        public ActionResult Index()
        {
            var listExams = new ExamDao().GetAllExams();
            return View(listExams);
        }


        [Authorize(Roles = "Admin, User")]
        public ActionResult Details(long examID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var exam = db.Exams.Where(m => m.ExamID == examID).FirstOrDefault();
                return PartialView("Details", exam);
            }
        }


        
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        //[ActionName("CheckCode")]
        public ActionResult CheckCode(string examCode, long examID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var session = (UserLogin)Session[new CommonConstant().USER_SESSION];
                var userID = session.UserID;
                var check = new ExamDao().CheckExam(examID, examCode, userID);


                var classExam = new ExamDao().GetClassExamID(userID, examID);
                var exam = new ExamDao().GetExamByID(examID);
                var modelExam = new ExamCustom();
                if (check)
                {
                    //return Json(check, JsonRequestBehavior.AllowGet);
                    modelExam = new ExamCustom
                    {
                        ClassExamID = classExam.ClassExamID,
                        ExamID = exam.ExamID,
                        QuantityQuestion = (int)exam.QuantityQuestion,
                        QuantityEasyQues = (int)exam.EasyQuestion,
                        QuantityMediumQues = (int)exam.NormalQuestion,
                        QuantityHardQues = (int)exam.HardQuestion,
                        ExamCategoryID = exam.ExamCategoryID,
                        UserID = userID
                    };
                    TempData["modelExam"] = modelExam;
                    //TRuyền qua xong nói t team view chạy. Miễn ren ở Action Attemp nhận dc TempData là dc
                    return Json(modelExam, JsonRequestBehavior.AllowGet);
                }
                return View();
            }
        }
    }
}