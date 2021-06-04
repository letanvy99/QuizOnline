using Model.Common;
using Model.Dao;
using Model.EF;
using Model.ModelCustom;
using Model.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{

    public class CreateClassController : BaseController
    {
        // GET: CreateClass

        // GET: Classes
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [Authorize(Roles = "Admin, User")]
        public ActionResult Create()
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                IEnumerable<UserCustom> listUser = new List<UserCustom>();
                listUser = db.Users.Where(o => o.UserName != "admin").Select(o => new UserCustom { UserID = o.UserID, UserName = o.UserName }).ToList();
                var userString = new ConvertJSON().ConvertToJSON(listUser);
                ViewBag.userString = userString;
                return View();
            }
        }


        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ActionName("AddNewClass")]
        public ActionResult Create(string enrolmentkey, string className, string classDes, long userid, string[] SelectedUserArray)
        {
            var checkclass = new ClassServices();
            var check = checkclass.CheckClassCustom(enrolmentkey, className);
            var listname = new ClassDao().GetAllNameClass(userid);
            int count = checkclass.CheckUserClass(userid, className);
            if (count == 0)
            {
                var classdao = new ClassDao();
                long classId = classdao.insertClass(enrolmentkey, className, classDes, userid);
                if (SelectedUserArray != null)
                {
                    for (int j = 0; j < SelectedUserArray.Length; j++)
                    {
                        var UserId = new UserDao().GetID(SelectedUserArray[j]);
                        var id = UserId.UserID;
                        new ClassUserDao().insertClassUser(new User_Class { ClassID = classId, UserID = id });
                    }
                }
                SetAlert("Tạo class thành công", "success");
                return Json(classId, JsonRequestBehavior.AllowGet);
            }
            SetAlert("Tên class đã tồn tại trên hệ thống", "error");
            return Json(userid, JsonRequestBehavior.AllowGet);


        }
    }
}
