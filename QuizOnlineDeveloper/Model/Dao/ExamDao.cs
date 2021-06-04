using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ExamDao
    {
        DBContent db = null;
        public ExamDao()
        {
            db = new DBContent();
        }
        public long countExams()
        {
            return db.Exams.Where(x => x.ExamID > 0).Count();
        }
    }
}
