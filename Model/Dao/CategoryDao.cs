using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    //LongTV16

    public class CategoryDao
    {
        public long countCategory()
        {
            using(DBCONTENT db = new DBCONTENT())
            {
                return db.Categories.Where(x => x.CategoryID > 0 && x.ParentID == null).Count();
            }
        }
        //LongTV16
        public long insertCategory(long? ParentID, string Typename)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var catelory = new Category { ParentID = ParentID, Typename = Typename, CreateAt = DateTime.Now };
                db.Categories.Add(catelory);
                db.SaveChanges();
                return catelory.CategoryID;
            }
        }
        //LongTV16
        public long insertCategoryUser(long categoryID, long userID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var catelory_user = new User_Categories { CategoryID = categoryID, UserID = userID };
                db.User_Categories.Add(catelory_user);
                db.SaveChanges();
                return catelory_user.UserCategoriesID;
            }
        }        
        //LongTV16
        public List<string> getCategoryname(long userID)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var listcate = (from uc in db.User_Categories
                                join c in db.Categories on uc.CategoryID equals c.CategoryID
                                join u in db.Users on uc.UserID equals u.UserID
                                where c.ParentID == null && u.UserID == userID
                                select c.Typename).ToList();
                return listcate;
            }
        }
    }
}
