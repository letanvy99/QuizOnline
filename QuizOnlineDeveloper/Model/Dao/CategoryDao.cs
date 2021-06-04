using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{

    public class CategoryDao
    {
        DBContent db = null;
        public CategoryDao()
        {
            db = new DBContent();
        }
        public long countCategory()
        {
            return db.Categories.Where(x => x.CategoryID > 0 && x.ParentID == null).Count();
        }
    }
}
