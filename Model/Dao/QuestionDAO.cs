using Model.EF;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class QuestionDAO
    {
        //VietTQ19
        public long AddQuestion(long categoryID, long userID, int levelQuestion, string QuestionContent, string Image,
            DateTime createAt, int? type)
        {
            Question question = new Question
            {
                CategoryID = categoryID,
                UserID = userID,
                LevelQuestion = levelQuestion,
                QuestionContent = QuestionContent,
                Image = Image,
                CreateAt = createAt,
                QuestionType = type
            };
            using (DBCONTENT db = new DBCONTENT())
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return question.QuestionID;
            }
        }

        //VietTQ19
        public long AddAnswer(long questionID, string answerContent, bool isChecked)
        {
            Answer answer = new Answer
            {
                QuestionID = questionID,
                AnswerContent = answerContent,
                IsTrue = isChecked
            };
            using (DBCONTENT db = new DBCONTENT())
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return answer.AnswerID;
            }
        }

        //VietTQ19
        public int CheckQuesTionTypeByExcel(string[] isCheck)
        {
            int type = 0;
            for (int j = 5; j < isCheck.Length; j += 2)
            {
                if (Convert.ToBoolean(Convert.ToInt32(isCheck[j])) == true)
                {
                    type++;
                }
            }
            return type == 0 ? -1 : (type == 1 ? 0 : 1);
        }

        //VIetTQ19
        public int CheckQuestionType(Dictionary<string, object>[] answerArray)
        {
            int type = 0;
            for (int i = 0; i < answerArray.Length; i++)
            {
                if ((bool)answerArray[i]["isChecked"] == true)
                {
                    type++;
                }
            }
            return type == 0 ? -1 : (type == 1 ? 0 : 1);
        }

        //LongTV16
        public List<Question> ListQuestionByCreateby(long userid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {

                return db.Questions.Where(x => x.CreateBy == userid).ToList();
            }
        }
        public IEnumerable<QuestionCustom> GetAllQuestionOnCatelory(string typename, long userID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                Question allquestion = new Question();
                var question = (from o in db.Questions
                                join x in db.Categories on o.CategoryID equals x.CategoryID
                                where x.Typename == typename && o.UserID == userID
                                select new QuestionCustom
                                {
                                    QuestionID = o.QuestionID,
                                    CategoryID = x.CategoryID,
                                    UserID = o.UserID,
                                    LevelQuestion = o.LevelQuestion,
                                    QuestionContent = o.QuestionContent,
                                    ParentID = x.ParentID,
                                    Typename = x.Typename,
                                    CreateBy = o.CreateBy,
                                    CreateAt = o.CreateAt
                                }
                                ).ToList();
                return question;
            }
        }
        public QuestionCustom GetQuestion(long quesID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var question = (from o in db.Questions
                                join x in db.Categories on o.CategoryID equals x.CategoryID
                                where o.QuestionID == quesID
                                select new QuestionCustom
                                {
                                    QuestionID = o.QuestionID,
                                    CategoryID = x.CategoryID,
                                    UserID = o.UserID,
                                    LevelQuestion = o.LevelQuestion,
                                    QuestionContent = o.QuestionContent,
                                    ParentID = x.ParentID,
                                    Typename = x.Typename,
                                    CreateBy = o.CreateBy,
                                    CreateAt = o.CreateAt,
                                    Image = o.Image,
                                    listAnsw = (from q in db.Answers
                                                where (q.QuestionID == o.QuestionID)
                                                select new AnswerCustom
                                                {
                                                    AnswerID = q.AnswerID,
                                                    AnswerContent = q.AnswerContent,
                                                    IsTrue = q.IsTrue
                                                }).ToList()
                                }
                                ).SingleOrDefault();
                return question;
            }
        }
        public bool EditQuestion(long updateby, long questionID, string questioncontent, int dokho, long hocphan,
            string[] answercontent, string[] Istrue, string image)
        {
            try
            {
                using (DBCONTENT db = new DBCONTENT())
                {
                    Question question = db.Questions.Find(questionID);
                    question.QuestionContent = questioncontent;
                    question.LevelQuestion = dokho;
                    question.CategoryID = hocphan;
                    question.Image = image;
                    var anslist = db.Answers.Where(x => x.QuestionID == questionID).ToList();
                    foreach (var item in anslist)
                    {
                        db.Answers.Remove(item);
                    }
                    for (int i = 0; i < answercontent.Length; i++)
                    {
                        Answer answer = new Answer();
                        answer.QuestionID = questionID;
                        answer.AnswerContent = answercontent[i];
                        answer.IsTrue = bool.Parse(Istrue[i]);
                        answer.UpdateAt = DateTime.Now;
                        answer.UpdateBy = updateby;
                        db.Answers.Add(answer);
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //VietTQ19
        public string[] GetQuestionContentByUserID(long userID)
        {
            using(DBCONTENT db = new DBCONTENT())
            {
                return db.Questions.Where(m => m.UserID == userID).Select(m =>m.QuestionContent).ToArray();
            }
        }
    }
}
