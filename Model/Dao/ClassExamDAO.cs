using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClassExamDAO
    {
        public long InsertExamForClass(long examID, long classID)
        {
            Class_Exams ce = new Class_Exams
            {
                ExamID = examID,
                ClassID = classID
            };
            using(DBCONTENT db= new DBCONTENT())
            {
                db.Class_Exams.Add(ce);
                db.SaveChanges();
            }
            return ce.ExamID;
        }

        //LongTV16
        public long countClassExam(long classid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Class_Exams.Where(x => x.ClassID == classid).Count();
            }
        }

        //LongTV16
        public bool DeleteAllExamClass(long classid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                try
                {
                    List<Class_Exams> emtity = db.Class_Exams.Where(x => x.ClassID == classid).ToList();
                    foreach (var item in emtity)
                    {
                        db.Class_Exams.Remove(item);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
