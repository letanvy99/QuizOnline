using Model.EF;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClassDao
    {
        public long countClass()
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Classes.Where(x => x.ClassID > 0).Count();
            }
        }

        public long insertClass(string enrolmentkey, string className, string classDes,long userID) 
        {
            Class classObj = new Class
            {
                ClassName = className,
                Description = classDes,
                CreateAt = DateTime.Now,
                Enrollmentkey = enrolmentkey,
                CreateBy = userID
            };
            using (DBCONTENT db = new DBCONTENT())
            {
                db.Classes.Add(classObj);
                db.SaveChanges();
            }
            return classObj.ClassID;
        }

        public List<Class> GetClass(long userid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Classes.Where(x => x.ClassID > 0 && x.CreateBy == userid).ToList();
            }
        }

        public Class GetClassIDByName(string ClassName)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Classes.SingleOrDefault(c => c.ClassName == ClassName);
            }
        }

        //VietTQ19
        // get ClassID by UserID
        public long[] GetClassIDByUserID(long userID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.User_Class.Where(m => m.UserID == userID).Select(m => m.ClassID).ToArray();
            }
        }

        //LongTV16
        public Class GetClassByID(long classID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Classes.Where(x => x.ClassID == classID).SingleOrDefault();
            }
        }

        //LongTV16
        public bool EditClass(string className, string classDes, string enrolmentkey, long userid, long classid)
        {
            try
            {
                using (DBCONTENT db = new DBCONTENT())
                {
                    Class oldClass = db.Classes.Find(classid);
                    oldClass.ClassName = className;
                    oldClass.Description = classDes;
                    oldClass.Enrollmentkey = enrolmentkey;
                    oldClass.UpdateAt = DateTime.Now;
                    oldClass.UpdateBy = userid;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //LongTV16
        public bool DeleteClass(long classid)
        {
            try
            {
                using (DBCONTENT db = new DBCONTENT())
                {
                    Class classdel = db.Classes.Find(classid);
                    db.Classes.Remove(classdel);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //LongTV16
        public List<Class> GetMyClass(long userid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var classlist = (from x in db.Classes
                                 join o in db.User_Class on x.ClassID equals o.ClassID
                                 where o.UserID == userid
                                 select x).ToList();
                return classlist;
            }
        }
        public List<Chart> Chart(long classID, string examname)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                List<Chart> listchart = new List<Chart>();
                //lấy ra class_exam_ID
                var Class_Exam_ID = (from x in db.Exams
                                     join l in db.Class_Exams on x.ExamID equals l.ExamID
                                     where x.ExamName == examname && l.ClassID == classID
                                     select l.ClassExamID).FirstOrDefault();
                //lấy ra toàn bộ username đã thi bài thi đó
                var username = (from o in db.User_Class_Exams
                                join x in db.Users on o.UserID equals x.UserID
                                where o.ClassExamID == Class_Exam_ID
                                select x.UserName
                            ).Distinct().ToList();
                //lấy ra bài thi có điểm số cao nhất và thời gian ngắn nhất của những sinh viên làm bài thi đó
                foreach (var item in username)
                {
                    var chartitem = (from o in db.User_Class_Exams
                                     join x in db.Users on o.UserID equals x.UserID
                                     where o.ClassExamID == Class_Exam_ID && x.UserName == item
                                     orderby o.MaxPoint descending
                                     orderby o.TimeComplete
                                     select new Chart
                                     {
                                         name = item,
                                         mark = (decimal)o.MaxPoint,
                                         time = (int)o.TimeComplete
                                     }
                                      ).Take(1).SingleOrDefault();
                    listchart.Add(chartitem);
                }
                //sắp xếp danh sách theo điểm và thời gian của 10 sinh viên làm bài thi đó.
                listchart = listchart.OrderByDescending(o => o.mark).ThenBy(o => o.time).Take(10).ToList();
                return listchart;
            }
        }
        public string GetnameExam(long examID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Exams.Where(x => x.ExamID == examID).Select(x => x.ExamName).SingleOrDefault();
            }

        }
        //lấy ra toàn bộ bài thi có thời gian kết thúc nhỏ hơn thời gian hiện tại
        public List<ExamCustom> GetAllExam(long classID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var listexam = (from x in db.Exams
                                join o in db.Class_Exams
                                on x.ExamID equals o.ExamID
                                where o.ClassID == classID && x.EndDay < DateTime.Now
                                select new ExamCustom
                                {
                                    ExamID = x.ExamID,
                                    ExamName = x.ExamName,
                                    ExamTime = (int)x.ExamTime,
                                    QuantityQuestion = (int)x.QuantityQuestion,
                                    StartD = (DateTime)x.StartDay,
                                    EndD = (DateTime)x.EndDay,
                                }
                                ).ToList();
                return listexam;
            }
        }
        //LongTV16
        public List<String> GetAllNameClass(long userid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Classes.Where(x => x.CreateBy == userid).Select(x => x.ClassName).ToList();
            }
        }
    }
}
