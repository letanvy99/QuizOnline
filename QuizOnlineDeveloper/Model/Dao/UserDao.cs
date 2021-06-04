using Model.EF;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        DBContent db = null;
        public UserDao()
        {
            db = new DBContent();
        }
        public long countUser()
        {
            return db.Users.Where(x => x.UserID > 0).Count();
        }
        public List<User> listAllUser()
        {
            return db.Users.Where(x => x.UserID > 0).ToList();
        }

        // VietTQ19: function Login
        public bool IsUser(string userName, string password)
        {
            using (DBContent db = new DBContent())
            {
                var userLogin = db.Users.Where(c => c.UserName == userName &&
                c.Password ==  password).FirstOrDefault();
                if (userLogin == null)
                {
                    return false;
                }
                return true;
            }
        }

        // VietTQ19: function get info User(để lưu vào session(Role, userName, ID))
        public User GetUserByID(string userName)
        {
            using (DBContent db = new DBContent())
            {
                return db.Users.SingleOrDefault(c => c.UserName == userName);
            }
        }
    }
}
