using Model.Dao;
using Model.EF;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Common;

namespace QuizOnlineDeveloper.Controllers
{
    public class BankController : BaseController
    {
        // GET: Bank
        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var sess = (UserLogin)Session[new CommonConstant().USER_SESSION];
                var listbank = (from x in db.Categories
                                join o in db.User_Categories
                                on x.CategoryID equals o.CategoryID
                                where o.UserID == sess.UserID
                                select x
                                ).ToList();
                var list = CategoryRequest.GenTreeView(listbank);
                var test = new ExamDao().getTypeName(sess.UserID);
                ViewBag.quizTest = test;
                return View(list);
            }

        }
        [Authorize(Roles = "Admin, User")]
        //Get List Question From Category
        public JsonResult Question(string typename)
        {
            var sess = (UserLogin)Session[new CommonConstant().USER_SESSION];
            var ques = new QuestionDAO().GetAllQuestionOnCatelory(typename,sess.UserID);
            return Json(ques, JsonRequestBehavior.AllowGet);
        }
        //Get Question From Category
        [Authorize(Roles = "Admin, User")]
        public JsonResult GetQuestion(long quesID)
        {
            var question = new QuestionDAO().GetQuestion(quesID);
            return Json(question, JsonRequestBehavior.AllowGet);
        }

        //Tạo bank
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Createbank()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Createbank(string TopicName, string[] BankArrr)
        {
            var sess = (UserLogin)Session[new CommonConstant().USER_SESSION];
            var listcate = new CategoryDao().getCategoryname(sess.UserID);
            ViewBag.listcate = listcate;
            int check = listcate.IndexOf(TopicName);
            if (check != -1)
            {
                SetAlert("Tạo bank thất bại", "error");
                return Json(sess, JsonRequestBehavior.AllowGet);
            }
            if (TopicName != null && check == -1)
            {
                long? ParentID = null;
                ParentID = new CategoryDao().insertCategory(ParentID, TopicName);
                new CategoryDao().insertCategoryUser((long)ParentID, sess.UserID);
                if (BankArrr == null) return View();
                else
                {
                    for (int i = 0; i < BankArrr.Length; i++)
                    {
                        if (BankArrr[i] != null)
                        {
                            var categoryid = new CategoryDao().insertCategory(ParentID, BankArrr[i]);
                            new CategoryDao().insertCategoryUser(categoryid, sess.UserID);
                        }
                    }
                    SetAlert("Tạo bank thành công", "success");
                    return Json(sess, JsonRequestBehavior.AllowGet);
                }
            }
            else return View();
        }
        
        //chỉnh sửa câu hỏi trong bank
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(long questionID, string questioncontent, int dokho, long hocphan, 
            string[] answercontent, string[] Istrue, string image)
        {
            var sess = (UserLogin)Session[new CommonConstant().USER_SESSION];
            bool check = new QuestionDAO().EditQuestion(sess.UserID, questionID, questioncontent,
                dokho, hocphan, answercontent, Istrue, image);
            return View();
        }
    }
}