using Model.Dao;
using Model.EF;
using Model.ModelCustom;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class AttemptQuizController : Controller
    {

        // GET: AttemptQuiz
        public ActionResult Attempt(ExamCustom exam, int questionNo = 1)
        {
            Session["EndTime"] = null;
            //ok co du lieuj r ne
            //get từ view ExamController
            if (TempData["modelExam"] != null)
            {
                ExamCustom std = (ExamCustom)TempData["modelExam"];
                exam = std;
                TempData["modelExam"] = null;
            }
            var dao = new ExamDao();
            //dao.addQuestionintoExamQuestions(2, 3, 1);
            //testingExam(long examID, int QuantityQuestion, long ExamCategoryID, long classExamID, long userID, int easy, int medium, int hard)
            var model = dao.testingExam(exam.ExamID, exam.QuantityQuestion, exam.ExamCategoryID, exam.ClassExamID, exam.UserID, exam.QuantityEasyQues, exam.QuantityMediumQues, exam.QuantityHardQues);
            ViewBag.QuestionNoMin = dao.getNumberMin(questionNo);
            ViewBag.QuestionNoMax = dao.getNumberMax(questionNo, model.Count);
            ViewBag.UserClassExamID = dao.getUserClassExamID(exam.UserID,exam.ClassExamID);// code cua mi do, userClassExamID chinh la classExamID do 
            if (Session["EndTime"] == null)
            {

                Session["EndTime"] = DateTime.Now.AddMinutes(dao.getTimer(exam.ClassExamID, exam.ExamID, exam.UserID)).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            TempData["EndTime"] = Session["EndTime"];
            TempData["User"] = dao.getUserInfo(exam.UserID, exam.ExamID, exam.ClassExamID);
            TempData["modelExam"] = exam;
            return View(model);
        }


        public ActionResult SaveAnswer(ExamCustom exam, AnswerModel choice, int? questionNo, string submit)
        {
            TempData["modelExam"] = exam;
            var dao = new ExamDao();
            TempData["User"] = dao.getUserInfo(exam.UserID, exam.ExamID, exam.ClassExamID);
            var UserClassExamID = choice.UserClassExamID;
            using (DBCONTENT db = new DBCONTENT())
            {
                if (choice.UserChoices != null)
                {

                    foreach (var item in choice.UserChoices)
                    {
                        if (item.answerID != null)
                        {
                            var UserQuestionID = db.User_Question.Where(x => x.QuestionID == item.questionID && x.UserClassExamID == UserClassExamID).FirstOrDefault().UserQuestionID;
                            db.User_Answers.RemoveRange(db.User_Answers.Where(x => x.UserQuestionID == UserQuestionID));
                            db.SaveChanges();

                            foreach (var itemchoice in item.answerID)
                            {
                                var IsRight = db.Answers.Where(x => x.QuestionID == item.questionID && x.AnswerID == itemchoice).FirstOrDefault().IsTrue;
                                db.User_Answers.Add(new User_Answers()
                                {
                                    AnswerID = itemchoice,
                                    UserQuestionID = UserQuestionID,
                                    IsRight = IsRight

                                    //thoi doi is true o answer
                                });
                                db.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in choice.QNB)
                    {
                        var UserQuestionID = db.User_Question.Where(x => x.QuestionID == item && x.UserClassExamID == UserClassExamID).FirstOrDefault().UserQuestionID;
                        db.User_Answers.RemoveRange(db.User_Answers.Where(x => x.UserQuestionID == UserQuestionID));
                        db.SaveChanges();
                    }
                }
            }
            if (submit != null)
            {
                return RedirectToAction("Points");
            }
            InfoUserTest user = (InfoUserTest)TempData["User"];
            
            return RedirectToAction("Attempt", new
            {
                @questionNo = questionNo
            });
        }

        public ActionResult Points(ExamCustom exam)
        {
            if (TempData["modelExam"] != null)
            {
                ExamCustom std = (ExamCustom)TempData["modelExam"];
                exam = std;
                //TempData["modelExam"] = null;
            }
            var examDao = new ExamDao();
            var userClassExamID = examDao.getUserClassExamID(exam.UserID, exam.ClassExamID);
            var listQuestionID = examDao.GetListQuestionIDWorked(userClassExamID);
            double totalScrore = 0;
            for (int i = 0; i < listQuestionID.Count; i++)
            {
                //get số câu đúng sai từ bank bởi questionID
                var IsTrueTrue = examDao.CountAnswerIsTrue(listQuestionID[i]);
                var IsTrueFalse = examDao.CountAnswerIsFalse(listQuestionID[i]);

                var userQuestionID = examDao.GetUserQuestionIDByQuestionID(listQuestionID[i]);

                var IsRightTrue = examDao.CountAnswerIsTrueWorked(userQuestionID);
                var IsRightFalse = examDao.CountAnswerIsFalseWorked(userQuestionID);

                var score = new CalculateScore().CalculateScoreForExam(IsTrueTrue, IsTrueFalse, IsRightTrue,
                    IsRightFalse, exam.QuantityQuestion);
                totalScrore += score;
               
            }
            examDao.UpdateScore(totalScrore, userClassExamID);

            return RedirectToAction("HistoryResult", "HistoryResult");
        }
    }
}