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
    public class CreateQuizController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create()
        {
            var sess = (Model.Common.UserLogin)Session[new Model.Common.CommonConstant().USER_SESSION];
            var userMakeQuiz = sess.UserID;
            var test = new ExamDao().getTypeName(userMakeQuiz);

            // create List Class to  convert to JSON
            IEnumerable<ClassToJSON> listClasses = new List<ClassToJSON>();
            using (DBCONTENT db = new DBCONTENT())
            {
                listClasses = db.Classes.Where(m =>m.CreateBy == sess.UserID).Select(o => new ClassToJSON { ClassID = o.ClassID, ClassName = o.ClassName }).ToList();
            }
            var classString = new ConvertJSON().ConvertToJSON(listClasses);
            ViewBag.classString = classString;
            ViewBag.quizTest = test;
            return View();
        }



        [HttpPost]
        [ActionName("CreateQuiz")]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create(string NameQuiz, long idcate, int TotalQ, int Remake, bool randomType, int Hard,
            int Normal, int Easy, DateTime DStart, DateTime DEnd, string Key, int TimeMakeQuiz, bool optionRandom, string[] NameSelectedArr)
        {
            if (ModelState.IsValid)
            {
                var sess = (Model.Common.UserLogin)Session[new Model.Common.CommonConstant().USER_SESSION];
                var CreateBy = sess.UserID;
                var ExamDao = new ExamDao();
                //return ExamID
                var EID = ExamDao.CreateExam(NameQuiz, idcate, TotalQ, Remake, randomType, Hard,
                     Normal, Easy, DStart, DEnd, Key, TimeMakeQuiz, optionRandom, CreateBy);

                for (int i = 0; i < NameSelectedArr.Length; i++)
                {
                    var classid = new ClassDao().GetClassIDByName(NameSelectedArr[i]);
                    var classExamID = new ClassExamDAO().InsertExamForClass(EID,classid.ClassID);
                }
                
                if (EID > 0)
                {
                    return RedirectToAction("Index", "exam");
                }
                else
                {
                    ModelState.AddModelError("", "Error Tạo Mới Bài Thi Thất Bại Vui Lòng Kiểm Tra Lại");
                }
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public ActionResult check(int idcate)
        {
            var ExamDao = new ExamDao();
            long[] check = new long[3];
            check[0] = ExamDao.countQuestion(idcate, 0);
            check[1] = ExamDao.countQuestion(idcate, 1);
            check[2] = ExamDao.countQuestion(idcate, 2);
            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}