using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClassUserDao
    {
        public long insertClassUser(User_Class classUser)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                db.User_Class.Add(classUser);
                db.SaveChanges();
                return classUser.UserClassID;
            }
        }

        // count user trong 1 class
        public long countClassUser(long classid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.User_Class.Where(x => x.ClassID == classid).Count();
            }
        }

        //LongTV16
        public List<User> ListUserByClassID(long classid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var userlist = (from x in db.Users
                                join o in db.User_Class on x.UserID equals o.UserID
                                where o.ClassID == classid
                                select x).ToList();
                return userlist;
            }
        }

        //LongTV16
        public bool DeleteUserClass(long userid, long classid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                try
                {
                    User_Class emtity = db.User_Class.Where(x => x.UserID == userid && x.ClassID == classid).SingleOrDefault();
                    db.User_Class.Remove(emtity);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        //LongTV16
        public bool DeleteAllUserClass(long classid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                try
                {
                    List<User_Class> emtity = db.User_Class.Where(x => x.ClassID == classid).ToList();
                    foreach (var item in emtity)
                    {
                        db.User_Class.Remove(item);
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
