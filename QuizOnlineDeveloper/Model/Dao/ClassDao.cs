using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClassDao
    {
        DBContent db = null;
        public ClassDao()
        {
            db = new DBContent();
        }
        public long countClass()
        {
            return db.Classes.Where(x => x.ClassID > 0).Count();
        }
    }
}
