using Model.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class UpdateUserController : BaseController
    {
        //[ActionName("GetUserInfo")]
        [HttpGet]
        public ActionResult Index()
        {
            var sess = (Model.Common.UserLogin)Session[new Model.Common.CommonConstant().USER_SESSION];
            var s = sess.UserID;
            using (DBCONTENT db = new DBCONTENT())
            {
                var user = db.Users.Where(u => u.UserID == s).ToList();
                var model = new User();
                foreach (var item in user)
                {
                    model.UserName = item.UserName;
                    model.Email = item.Email;
                    model.FullName = item.FullName;
                    model.PhoneNumber = item.PhoneNumber;
                    model.Address = item.Address;
                }
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult Index(User users)
        {
            // Thiếu check sdt 10 số
            using (DBCONTENT db = new DBCONTENT())
            {
                var user = new UserDao().GetUserByID(users.UserName);
                var model = db.Users.Find(user.UserID);
                model.FullName = users.FullName;
                model.PhoneNumber = users.PhoneNumber;
                model.Address = users.Address;

                db.SaveChanges();
                return View(model);
            }
        }
        public ActionResult UpdatePass(string oldpass, string newpass)
        {
            oldpass = Encryptor.MD5Hash(oldpass);
            newpass = Encryptor.MD5Hash(newpass);
            var sess = (Model.Common.UserLogin)Session[new Model.Common.CommonConstant().USER_SESSION];
            var s = sess.UserID;

            using (DBCONTENT db = new DBCONTENT())
            {
                var model = db.Users.Find(s);
                var pass = model.Password;
                if (pass.Equals(oldpass))
                {
                    model.Password = newpass;
                    db.SaveChanges();
                    SetAlert("Đổi mật khẩu thành công", "success");
                    return Json(newpass, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SetAlert("Đổi mật khẩu thất bại.", "error");
                    return Json(newpass, JsonRequestBehavior.AllowGet);
                }
            }

        }
    }
}