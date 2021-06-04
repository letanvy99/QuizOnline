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
    public class ClassManagermentController : BaseController
    {
        public string ConvertToJSON(IEnumerable<UserCustom> list)
        {
            return JsonConvert.SerializeObject(list);
        }
        // GET: ClassManagerment
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            var sess = (Model.Common.UserLogin)Session[new Model.Common.CommonConstant().USER_SESSION];
            var classes = new ClassDao();
            var classlist = classes.GetClass(sess.UserID);
            return View(classlist);
        }

        //controller trang khóa học tôi tham gia
        [Authorize(Roles = "Admin, User")]
        public ActionResult MyClass()
        {
            var sess = (Model.Common.UserLogin)Session[new Model.Common.CommonConstant().USER_SESSION];
            var classes = new ClassDao();
            var classlist = classes.GetMyClass(sess.UserID);
            return View(classlist);
        }

        [Authorize(Roles = "Admin, User")]
        //controller trang chi tiết
        [HttpGet]
        public ActionResult Detail(long ClassId)
        {
            var listclassexam = new ClassDao().GetAllExam(ClassId);
            ViewBag.ListExam = listclassexam;
            var classes = new ClassDao().GetClassByID(ClassId);
            return View(classes);
        }


        [Authorize(Roles = "Admin, User")]
        public ActionResult Seach()
        {
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult Delete(long userid, long classid)
        {
            new ClassUserDao().DeleteUserClass(userid, classid);
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public ActionResult Edit(long classId)
        {
            using (DBCONTENT db = new DBCONTENT())
            {
                var listUser = db.Users.Select(o => new UserCustom { UserID = o.UserID, UserName = o.UserName }).ToList();
                var userString = ConvertToJSON(listUser);
                ViewBag.userString = userString;
                var classes = new ClassDao().GetClassByID(classId);
                return View(classes);
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult Edit(string enrolmentkey, string className, string classDes, long userid, long classid, string[] SelectedUserArray)
        {
            var checkclass = new ClassServices();
            var check = checkclass.CheckClassCustom(enrolmentkey, className);
            if (check)
            {
                var classdao = new ClassDao();
                bool checkedit = classdao.EditClass(className, classDes, enrolmentkey, userid, classid);
                if (checkedit)
                {
                    bool checkdeluserclass = new ClassUserDao().DeleteAllUserClass(classid);
                    for (int i = 0; i < SelectedUserArray.Length; i++)
                    {
                        var UserId = new UserDao().GetID(SelectedUserArray[i]);
                        var id = UserId.UserID;

                        if (checkdeluserclass)
                        {
                            new ClassUserDao().insertClassUser(new User_Class { ClassID = classid, UserID = id });
                        }
                    }
                }
            }
            return View("Index", "ClassManagerment");
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult DeleteClass(long classid)
        {
            new ClassExamDAO().DeleteAllExamClass(classid);
            new ClassUserDao().DeleteAllUserClass(classid);
            new ClassDao().DeleteClass(classid);
            return View();
        }
        [Authorize(Roles = "Admin, User")]
        public JsonResult Chart(long classID, long examID)
        {
            var examname = new ClassDao().GetnameExam(examID);
            var chart = new ClassDao().Chart(classID, examname);
            return Json(chart, JsonRequestBehavior.AllowGet);
        }
    }
}