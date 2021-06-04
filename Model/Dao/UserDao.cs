using Model.EF;
using Model.ModelCustom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        DBCONTENT db = null;
        public UserDao()
        {
            db = new DBCONTENT();
        }
        public User GetID(string username)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                return db.Users.SingleOrDefault(x => x.UserName == username);
            }
        }
        public void setOffline(string userName)
        {
            var user = new UserDao().GetUserByID(userName);
            var userid = db.Users.Find(user.UserID);
            userid.Online = false;
            db.SaveChanges();
        }
        public void setOnline(string userName)
        {
            var user = new UserDao().GetUserByID(userName);
            var userid = db.Users.Find(user.UserID);
            userid.Online = true;
            db.SaveChanges();
        }

        // VietTQ19: function Login
        public bool IsUser(string userName, string password)
        {
            var userLogin = db.Users.Where(c => c.UserName == userName &&
            c.Password == password).FirstOrDefault();
            if (userLogin == null)
            {
                return false;
            }
            else
            {
                if (userLogin.IsValidEmail == false)
                {
                    return false;
                }
                new UserDao().setOnline(userName);
            }
            return true;
        }

        // VietTQ19: function get info User(để lưu vào session(Role, userName, ID))
        public User GetUserByID(string userName)
        {
            return db.Users.SingleOrDefault(c => c.UserName == userName);
        }
        // coutn tổng số User
        public long countUser()
        {
            return db.Users.Where(x => x.UserID > 0).Count();
        }

        //get name theo ID
        public string GetName(long userid)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var user = db.Users.SingleOrDefault(x => x.UserID == userid);
                return user.FullName;
            }
        }

        public List<User> listAllUser()
        {
            return db.Users.Where(x => x.UserID > 0).ToList();
        }
        public List<User> ViewDetail(int id)
        {
            return db.Users.Where(x => x.UserID == id).ToList();
        }
        public bool ChangeStatus(long id, string commentlock)
        {
            var user = db.Users.Find(id);
            if (user.LockStatus == true)
            {
                user.LockStatus = !user.LockStatus;
                user.LockNote = "";
                db.SaveChanges();
            }
            else
            {
                user.LockStatus = !user.LockStatus;
                user.LockNote = commentlock;
                db.SaveChanges();
            }
            return (bool)user.LockStatus;
        }
        public long countUserbyDay(DateTime date)
        {
            var newDate = new DateTime(date.Year, date.Month, date.Day);
            return db.Users.Where(x => x.CreateAt == newDate).Count();
        }
        public string ConvertToJSON(IEnumerable<UserCharts> list)
        {
            return JsonConvert.SerializeObject(list);
        }
        public bool checkUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool checkEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
        public long InsertUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return GetUserByID(user.UserName).UserID;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public void ValidateEmail(string id)
        {
            var user = db.Users.Where(x => x.Activatecode == id).SingleOrDefault();
            user.IsValidEmail = true;
            user.Activatecode = null;
            db.SaveChanges();
        }
        public long GetUserIDbyEmail(string email)
        {
            return db.Users.SingleOrDefault(x => x.Email == email).UserID;
        }
        public void addResetCode(string code, string email)
        {
            var user = db.Users.Where(x => x.Email == email).SingleOrDefault();
            user.ResetPassCode = code;
            db.SaveChanges();
        }
        public void addActiveCode(string code, string userName)
        {
            var user = db.Users.Where(x => x.UserName == userName).SingleOrDefault();
            user.Activatecode = code;
            db.SaveChanges();
        }
        public bool resetPassword(string resetcode, string password)
        {
            try
            {

                var user = db.Users.Where(x => x.ResetPassCode == resetcode).FirstOrDefault();
                user.Password = password;
                user.ResetPassCode = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool checkCodeReset(string code)
        {
            return db.Users.Where(x => x.ResetPassCode == code).FirstOrDefault() != null;
        }
        public void addUserRole(long userID, int RoleID)
        {
            var userRole = new UserRolesMapping();
            userRole.UserID = userID;
            userRole.RoleID = RoleID;
            db.UserRolesMappings.Add(userRole);
            db.SaveChanges();
        }
    }
}
