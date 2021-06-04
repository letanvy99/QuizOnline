using Model.EF;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ExamDao
    {
        public long countExams()
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Exams.Where(x => x.ExamID > 0).Count();
            }
        }

        //QUangNVV
        public IEnumerable<CreateQuiz> getTypeName(long UserID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var test = (from uc in db.User_Categories
                            join c in db.Categories on uc.CategoryID equals c.CategoryID
                            join u in db.Users on uc.UserID equals u.UserID
                            where c.ParentID == null && u.UserID == UserID
                            select new CreateQuiz()
                            {
                                UserID = u.UserID,
                                CategoryID = c.CategoryID,
                                TypeName = c.Typename
                            }).ToList();
                return test;
            }
        }

        //QuangNVV
        public long CreateExam(string NameQuiz, long idcate, int TotalQ, int Remake, bool randomType, int Hard,
             int Normal, int Easy, DateTime DStart, DateTime DEnd, string Key, int TimeMakeQuiz, bool optionRandom, long CreateBy)
        {
            Exam exam = new Exam
            {
                ExamName = NameQuiz,
                ExamCategoryID = idcate,
                QuantityQuestion = TotalQ,
                QuantityTest = Remake,
                IsShowResult = randomType,
                HardQuestion = Hard,
                NormalQuestion = Normal,
                EasyQuestion = Easy,
                StartDay = DStart,
                EndDay = DEnd,
                AcceptCode = Key,
                ExamTime = TimeMakeQuiz,
                TypeRandom = optionRandom,
                CreateBy = CreateBy
            };
            using (DBCONTENT db = new DBCONTENT())
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return exam.ExamID;
            }

        }

        //VietTQ19
        public List<Exam> GetAllExams()
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var listExams = db.Exams.ToList();
                return listExams;
            }
        }

        //VietTQ19 check examcode %% startdate <= DatetimeNow %% endate >= Datetime.Now
        public bool CheckExamCode(string code, long examID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {

                //You should be doing DbFunctions.DiffDays(DateTime.Now, x.MyDate) since it's supposed to work like subtracting 
                //the first parameter from the second one, so in your case, the DiffDays is returning a negative number.

                //Summarizing it if you have DbFunctions.DiffDays(date1, date2)

                //and date1 > date2 the result will be< 0

                //and date1<date2 the result will be > 0


                var check = db.Exams.Where(m => m.ExamID == examID
                        && m.AcceptCode == code
                        //&& ((int)((DateTime.Now - m.StartDay.Value).TotalHours) > 0)

                        //&& DbFunctions.DiffMinutes(DateTime.Now, m.StartDay) < 0
                        //&& DbFunctions.DiffMinutes(m.EndDay, DateTime.Now) < 0
                        && DbFunctions.DiffSeconds(DateTime.Now, m.StartDay) < 0
                        && DbFunctions.DiffSeconds(m.EndDay, DateTime.Now) < 0
                        /*&& ((int)((m.EndDay.Value - DateTime.Now).TotalHours) > 0)*/).Any();

                return check;
            }
        }

        //Viettq19
        public bool CheckClassExam(long examID, long classID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var check = db.Class_Exams.Where(m => m.ClassID == classID && m.ExamID == examID).Any();
                return check;
            }
        }

        //VietTQ19
        public bool CheckExam(long examID, string code, long userID)
        {
            var checkExamCode = CheckExamCode(code, examID);
            if (checkExamCode)
            {
                // get array ClassID
                var classID = new ClassDao().GetClassIDByUserID(userID);
                for (int i = 0; i < classID.Length; i++)
                {
                    if (CheckClassExam(examID, classID[i]))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        //QuangNVV
        public IEnumerable<HistoryResult> GetListResult(long userClassExamID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var list = (from uce in db.User_Class_Exams
                            join ce in db.Class_Exams on uce.ClassExamID equals ce.ClassExamID
                            join u in db.Users on uce.UserID equals u.UserID
                            join c in db.Classes on ce.ClassID equals c.ClassID
                            join e in db.Exams on ce.ExamID equals e.ExamID
                            where uce.UserClassExamID == userClassExamID
                            select new HistoryResult
                            {
                                UserClassExamID = uce.UserClassExamID,
                                ExamName = e.ExamName,
                                ClassName = c.ClassName,
                                TimeComplete = (int)uce.TimeComplete,
                                MaxPoint = (decimal)uce.MaxPoint,
                                //QuantityTested = (int)uce.QuantityTested
                            }).ToList();
                //var list = (from uce in db.User_Class_Exams
                //            join ce in db.Class_Exams on uce.ClassExamID equals ce.ClassExamID
                //            join u in db.Users on uce.UserID equals u.UserID
                //            join c in db.Classes on ce.ClassID equals c.ClassID
                //            join e in db.Exams on ce.ExamID equals e.ExamID
                //            where u.UserID == Userid select uce).ToList();
                return list;
            }
        }


        /// <summary>
        /// Sửa User_Question
        /// </summary>
        /// <param name="UserClassExamID"></param>
        /// <returns></returns>
        /// 

        //public DetailQuizResuilt GetDetailResuilt(long UserClassExamID)
        //{

        //    using (DBCONTENT db = new DBCONTENT())
        //    {
        //        var DetailResuilt = (from uce in db.User_Class_Exams
        //                             join ce in db.Class_Exams on uce.ClassExamID equals ce.ClassExamID
        //                             join u in db.Users on uce.UserID equals u.UserID
        //                             join c in db.Classes on ce.ClassID equals c.ClassID
        //                             join e in db.Exams on ce.ExamID equals e.ExamID
        //                             join uqa in db.User_Question_Answers on uce.UserClassExamID equals uqa.UserClassExamID
        //                             join q in db.Questions on uqa.QuestionID equals q.QuestionID
        //                             join a in db.Answers on q.QuestionID equals a.QuestionID
        //                             where uce.UserClassExamID == UserClassExamID
        //                             select new DetailQuizResuilt()
        //                             {
        //                                 ExamName = e.ExamName,
        //                                 ClassName = c.ClassName,
        //                                 TimeComplete = (int)uce.TimeComplete,
        //                                 MaxPoint = (int)uce.MaxPoint,
        //                                 QuantityQuestion = (int)e.QuantityQuestion,
        //                                 UserQuestionAnswersID = uqa.UserQuestionAnswersID,
        //                                 QuestionID = q.QuestionID,
        //                                 AnswerID = a.AnswerID,
        //                                 IsRight = (bool)a.IsTrue

        //                             }).FirstOrDefault();
        //        return DetailResuilt;
        //    }
        //}


        /// <summary>
        /// Sửa chỗ ni nghe
        /// </summary>
        /// <param name="UserClassExamID"></param>
        /// <returns></returns>
        //public IEnumerable<listAnswer> GetListAnswers(long UserClassExamID)
        //{
        //    using (DBCONTENT db = new DBCONTENT())
        //    {
        //        var list = (from uqa in db.User_Question_Answers
        //                    where uqa.UserClassExamID == UserClassExamID
        //                    select new listAnswer()
        //                    {
        //                        UserClassExamID = uqa.UserClassExamID,
        //                        IsRight = uqa.IsRight

        //                    }).ToList();
        //        return list;
        //    }
        //}

        //public long countRightAnswer(long userclassexamID)
        //{
        //    using (DBCONTENT db = new DBCONTENT())
        //    {
        //        return db.User_Question_Answers.Where(o => o.IsRight == true && o.UserClassExamID == userclassexamID).Count();
        //    }
        //}
        //public long countWrongAnswer(long userclassexamID)
        //{
        //    using (DBCONTENT db = new DBCONTENT())
        //    {
        //        return db.User_Question_Answers.Where(o => o.IsRight == false && o.UserClassExamID == userclassexamID).Count();
        //    }
        //}
        //QuangNVV
        public long countQuestion(long CatagoryID, int LevelQuestion)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var a = (from c in db.Categories
                         join q in db.Questions on c.CategoryID equals q.CategoryID
                         where  c.CategoryID == CatagoryID && q.LevelQuestion == LevelQuestion
                         select q.QuestionID).Count();
                return a;
            }
        }
        //lai di


        //VietTQ19
        public Exam GetExamByID(long examID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Exams.Where(o => o.ExamID == examID).FirstOrDefault();
            }
        }

        //VietTQ19
        public Class_Exams GetClassExamID(long userID, long ExamID)
        {

            using (DBCONTENT db = new DBCONTENT())
            {
                var classID = new ClassDao().GetClassIDByUserID(userID);
                var classExamID = new Class_Exams();
                // Bài thi 1 cho 2 lớp thi, 1 sinh viên A thuộc cả 2 lớp 1 & 2 đó thì
                // ưu tiên lấy bản ghi đầu tiên được tìm thấy => classExamID ==1 
                // ClassExamID      ClassID     ExamID
                //     1                1           1
                //     2                2           1   
                for (int i = 0; i < classID.Length; i++)
                {
                    var temp = classID[i];
                    classExamID = db.Class_Exams.Where(o => o.ExamID == ExamID && o.ClassID == temp).FirstOrDefault();
                    if (classExamID != null)
                        break;
                }
                return classExamID;
            }
        }
        public long getUserClassExamID(long userID, long ClassExamID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.User_Class_Exams.Where(x => x.UserID == userID && x.ClassExamID == ClassExamID).FirstOrDefault().UserClassExamID;
            }
        }

        //VietTQ19
        public List<long> GetExamIDByClassID(long classID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var list = (from ce in db.Class_Exams
                            join
  e in db.Exams on ce.ExamID equals e.ExamID
                            where ce.ClassID == classID
                            select e.ExamID).Distinct().ToList();
                return list;
            }
        }





        //Vy
        /// <summary>
        /// Get all question in bank by examcategoryID
        /// </summary>
        /// <param name="ExamCategoryID"></param>
        /// <returns></returns>
        public List<QuestionCustom> GetListQuestion(long ExamCategoryID,long examID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var list = (from exam in db.Exams
                            join category in db.Categories
                            on exam.ExamCategoryID equals category.CategoryID
                            join question in db.Questions
                            on category.CategoryID equals question.CategoryID
                            where exam.ExamCategoryID == ExamCategoryID && exam.ExamID == examID
                            select new QuestionCustom()
                            {
                                QuestionID = question.QuestionID,
                                QuestionContent = question.QuestionContent,
                                LevelQuestion = question.LevelQuestion
                            }).ToList();
                return list;
            }
        }
        /// <summary>
        /// Random type question, easy 0, medium 1, hard 2
        /// </summary>
        /// <param name="list"></param>
        /// <param name="numberquestion"></param>
        /// <returns></returns>
        public List<QuestionCustom> RandomQuestionEachType(List<QuestionCustom> list, int numberquestion, int type)
        {
            var listquestion = list.Where(x => x.LevelQuestion == type).ToList();
            HashSet<int> newSet = new HashSet<int>();
            var random = new Random();
            var listResult = new List<QuestionCustom>();
            if (numberquestion == 0 || listquestion.Count == 0)
            {
                return listResult;
            }
            if (numberquestion <= list.Count)
            {
                do
                {
                    newSet.Add(random.Next(listquestion.Count));
                } while (newSet.Count < numberquestion);
                foreach (var item in newSet)
                {
                    listResult.Add(listquestion[item]);
                }
                return listResult;
            }
            else
            {
                do
                {
                    newSet.Add(random.Next(listquestion.Count));
                } while (newSet.Count < listquestion.Count);
                foreach (var item in newSet)
                {
                    listResult.Add(listquestion[item]);
                }
                return listResult;
            }
        }
        /// <summary>
        /// Random Question from bank follow how many question
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ExamCategoryID"></param>
        /// <param name="easy"></param>
        /// <param name="medium"></param>
        /// <param name="hard"></param>
        /// <returns></returns>
        public List<QuestionCustom> randomQuestionfromBank(List<QuestionCustom> list, int easy, int medium, int hard)
        {
            List<QuestionCustom> questionCustoms = new List<QuestionCustom>();
            var total = easy + medium + hard;
            if (total <= list.Count)
            {
                var questionHard = RandomQuestionEachType(list, hard, 2);
                if (questionHard.Count != 0)
                {
                    foreach (var item in questionHard)
                    {
                        questionCustoms.Add(item);
                    }
                }
                var questionMedium = RandomQuestionEachType(list, medium + (hard - questionHard.Count), 1);
                if (questionMedium.Count != 0)
                {
                    foreach (var item in questionMedium)
                    {
                        questionCustoms.Add(item);
                    }
                }
                var questionEasy = RandomQuestionEachType(list, easy + (medium - questionMedium.Count), 0);
                if (questionEasy.Count != 0)
                {
                    foreach (var item in questionEasy)
                    {
                        questionCustoms.Add(item);
                    }
                }
                return questionCustoms;
            }
            else
            {
                return questionCustoms;
            }

        }
        /// <summary>
        /// Add question trong Bài kiểm tra
        /// </summary>
        /// <param name="examID"></param>
        /// <param name="QuantityQuestion"></param>
        /// <param name="ExamCategoryID"></param>
        /// <returns></returns>
        public string addQuestionintoExamQuestions(long examID, int QuantityQuestion, long ExamCategoryID, int easy, int medium, int hard)
        {
            try
            {
                using (DBCONTENT db = new DBCONTENT())
                {
                    var listquestion = GetListQuestion(ExamCategoryID,examID);
                    var list = randomQuestionfromBank(listquestion, easy, medium, hard);
                    if (db.Exam_Questions.Where(x => x.ExamID == examID).Count() < list.Count && db.Exam_Questions.Where(x => x.ExamID == examID).Count() > list.Count)
                    {
                        db.Exam_Questions.RemoveRange(db.Exam_Questions.Where(x => x.ExamID == examID));
                    }
                    if (db.Exam_Questions.Where(x => x.ExamID == examID).Count() == list.Count)
                    {
                        return "Added";
                    }
                    else
                    {

                        if (list.Count > 0)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (i < QuantityQuestion)
                                {
                                    var exam = new Exam_Questions()
                                    {
                                        ExamID = examID,
                                        QuestionID = list[i].QuestionID
                                    };
                                    db.Exam_Questions.Add(exam);
                                    db.SaveChanges();
                                }
                            }
                            return "Added";
                        }
                        return "Not enough questions";

                    }

                }
            }
            catch
            {
                return "try catch";
            }

        }
        /// <summary>
        /// Chưa làm save vào bảng user class Exam
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveInUserQuestion(List<ViewQuestion> list, long classExamID, long userID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var listUserClassExam = db.User_Class_Exams.Where(x => x.ClassExamID == classExamID && x.UserID == userID).ToList();
                if (listUserClassExam.Count > 0)
                {
                    return false;
                }
                else
                {
                    var UserClassExam = new User_Class_Exams();
                    UserClassExam.UserID = userID;
                    UserClassExam.ClassExamID = classExamID;
                    UserClassExam.MaxPoint = 0;
                    UserClassExam.startExam = DateTime.Now;
                    db.User_Class_Exams.Add(UserClassExam);
                    db.SaveChanges();

                    var UserClassExamID = db.User_Class_Exams.Where(x => x.ClassExamID == classExamID && x.UserID == userID).FirstOrDefault().UserClassExamID;
                    if (db.User_Question.Where(x => x.UserClassExamID == UserClassExamID).ToList().Count() > 0)
                    {
                        return false;
                    }
                    foreach (var item in list)
                    {
                        var answerQuestion = new User_Question();
                        answerQuestion.QuestionID = item.QuestionID;
                        answerQuestion.UserClassExamID = UserClassExamID;
                        db.User_Question.Add(answerQuestion);
                        db.SaveChanges();
                    }
                    return true;
                }


            }
        }
        public List<ViewQuestion> testingExam(long examID, int QuantityQuestion, long ExamCategoryID, long classExamID, long userID, int easy, int medium, int hard)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var model = new List<ViewQuestion>();
                var exam = db.Exams.Find(examID);
                var typeRandom = exam.TypeRandom;
                //random ko ai giong ai
                if (typeRandom == true)
                {
                    var listquestion = GetListQuestion(ExamCategoryID,examID);
                    var list = randomQuestionfromBank(listquestion, easy, medium, hard);
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            model.Add(new ViewQuestion()
                            {
                                QuestionID = item.QuestionID
                            });
                        }
                    }
                    SaveInUserQuestion(model, classExamID, userID);
                    var UserClassExamID = db.User_Class_Exams.Where(x => x.ClassExamID == classExamID && x.UserID == userID).FirstOrDefault().UserClassExamID;
                    model = db.User_Question.Where(x => x.UserClassExamID == UserClassExamID).Select(x => new ViewQuestion()
                    {
                        QuestionID = x.QuestionID,
                        Image = x.Question.Image,
                        ExamID = examID,
                        QuestionContent = x.Question.QuestionContent,
                        QuestionType = x.Question.QuestionType,
                        LevelQuestion = x.Question.LevelQuestion,
                        Options = x.Question.Answers.Select(y => new AnswerxQuestion()
                        {
                            AnswerID = y.AnswerID,
                            AnswerContent = y.AnswerContent,
                            Check = false,
                            isTrue = y.IsTrue

                        }).ToList()
                    }).ToList();
                    model = SaveAnswer(UserClassExamID, model);
                    return model;
                }
                //random giong het

                else
                {
                    var check = addQuestionintoExamQuestions(examID, QuantityQuestion, ExamCategoryID, easy, medium, hard);
                    if (check == "Added")
                    {
                        model = db.Exam_Questions.Where(x => x.ExamID == examID).Select(x => new ViewQuestion()
                        {
                            QuestionID = x.QuestionID,
                            ExamID = x.ExamID,
                            Image = x.Question.Image,
                            QuestionContent = x.Question.QuestionContent,
                            QuestionType = x.Question.QuestionType,
                            LevelQuestion = x.Question.LevelQuestion,
                            Options = x.Question.Answers.Select(y => new AnswerxQuestion()
                            {
                                AnswerID = y.AnswerID,
                                AnswerContent = y.AnswerContent,
                                Check = false,
                                isTrue = y.IsTrue

                            }).ToList()
                        }).ToList();

                        SaveInUserQuestion(model, classExamID, userID);
                        var UserClassExamID = db.User_Class_Exams.Where(x => x.ClassExamID == classExamID && x.UserID == userID).FirstOrDefault().UserClassExamID;
                        model = SaveAnswer(UserClassExamID, model);
                        return model;
                    }
                    else
                    {
                        return model;
                    }
                }
            }
        }
        public List<ViewQuestion> SaveAnswer(long UserClassExamID, List<ViewQuestion> model)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var UserQuestion = db.User_Question.Where(x => x.UserClassExamID == UserClassExamID).Select(x => x.UserQuestionID).ToList();
                List<long> savedAnswer = new List<long>();
                foreach (var item in UserQuestion)
                {
                    var answerID = db.User_Answers.Where(x => x.UserQuestionID == item).Select(x => x.AnswerID);
                    if (answerID != null)
                    {
                        savedAnswer.AddRange(answerID);
                    }

                }
                if (savedAnswer != null)
                {
                    foreach (var item in savedAnswer)
                    {
                        foreach (var itemModel in model)
                        {
                            foreach (var itemAnswer in itemModel.Options)
                            {
                                if (itemAnswer.AnswerID == item)
                                {
                                    itemAnswer.Check = true;
                                }
                            }
                        }
                    }
                }
                return model;
            }

        }


        public int getNumberMin(int questionNo)
        {
            var result = 0;
            if (questionNo % 5 == 0 && questionNo > 0)
            {
                result = questionNo - 4;
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    if ((questionNo + i) % 5 == 0)
                    {
                        result = questionNo - (4 - i);
                    }
                }
            }
            return result;

        }
        public int getNumberMax(int questionNo, int total)
        {
            var result = 0;
            if (questionNo % 5 == 0 && questionNo > 0)
            {
                result = questionNo;
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    if (questionNo + i == total)
                    {
                        result = total;
                        break;
                    }
                    if ((questionNo + i) % 5 == 0)
                    {
                        result = questionNo + i;
                        break;
                    }
                }
            }
            return result;

        }
        public double getTimer(long classExamID, long examID,long userID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var timeStart = db.User_Class_Exams.Where(x => x.ClassExamID == classExamID && x.UserID ==userID).FirstOrDefault().startExam;
                var timeTest = db.Exams.Find(examID).ExamTime;
                timeStart = timeStart.AddMinutes(timeTest);
                DateTime dt1 = DateTime.Now;
                TimeSpan ts = (timeStart - dt1);
                return ts.Minutes+1;
            }
        }
        public InfoUserTest getUserInfo(long userID, long ExamID, long ClassExamID)
        {
            InfoUserTest model = new InfoUserTest();
            using (DBCONTENT db = new DBCONTENT())
            {
                model.NameExam = db.Exams.Where(x => x.ExamID == ExamID).FirstOrDefault().ExamName;
                var user = db.Users.Find(userID);
                var ClassID = db.Class_Exams.Find(ClassExamID).ClassID;
                model.ClassName = db.Classes.Find(ClassID).ClassName;
                model.UserName = user.UserName;
                model.FullName = user.FullName;
                model.Date = DateTime.Now.ToString("dd/MM/yyyy");
            }
            return model;
        }

        //VietTQ19
        //get ra danh sách questionID đã làm trong bài thi của UserĐó
        public List<long> GetListQuestionIDWorked(long userClassExamID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.User_Question.Where(m => m.UserClassExamID == userClassExamID).Select(m => m.QuestionID).ToList();
            }
        }

        //VietTQ19
        // get userQuestionID by questionID to count IsRightTrue/False in UserAnswer
        public long GetUserQuestionIDByQuestionID(long questionID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.User_Question.Where(m => m.QuestionID == questionID).Select(m => m.UserQuestionID).FirstOrDefault();
            }
        }

        //VietTQ19
        // tính số đáp án đúng của câu hỏi trong ngân hàng khi truyền vào questionID
        public int CountAnswerIsTrue(long questionID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Answers.Where(m => m.QuestionID == questionID && m.IsTrue == true).Count();
            }
        }

        //VietTQ19
        // tính số đáp án sai của câu hỏi trong ngân hàng khi truyền vào questionID
        public int CountAnswerIsFalse(long questionID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Answers.Where(m => m.QuestionID == questionID && m.IsTrue == false).Count();
            }
        }

        //VietTQ19
        // tính số đáp án đúng user đã trả lời
        public int CountAnswerIsTrueWorked(long UserQuestionID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.User_Answers.Where(m => m.UserQuestionID == UserQuestionID && m.IsRight == true).Count();
            }
        }

        //VietTQ19
        // tính số đáp án sai user dã trả lời
        public int CountAnswerIsFalseWorked(long UserQuestionID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.User_Answers.Where(m => m.UserQuestionID == UserQuestionID && m.IsRight == false).Count();
            }
        }

        //VietTQ19
        public void UpdateScore(double scrore, long userClassExamID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var model = db.User_Class_Exams.Find(userClassExamID);
                model.MaxPoint = (decimal)scrore;
                TimeSpan ts = DateTime.Now - model.startExam;
                model.TimeComplete = (int)ts.TotalSeconds;
                db.SaveChanges();
            }
        }

        ////VietTQ19
        //// get Datetime StartExam
        //public DateTime GetTimeCompleteExam(long UserClassExamID)
        //{
        //    using (DBCONTENT db = new DBCONTENT())
        //    {
        //        var startExam = db.User_Class_Exams.Where(m => m.UserClassExamID == UserClassExamID).FirstOrDefault().startExam;

        //    }
        //}
    }
}
