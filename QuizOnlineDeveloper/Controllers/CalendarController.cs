using Microsoft.AspNet.SignalR.Messaging;
using Model.Common;
using Model.Dao;
using Model.EF;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class CalendarController : BaseController
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCalendarData()
        {


            using (DBCONTENT db = new DBCONTENT())
            {
                var sess = (UserLogin)Session[new CommonConstant().USER_SESSION];
                var classID = new ClassDao().GetClassIDByUserID(sess.UserID);
                List<long> temp = new List<long>();
                List<long> examID = new List<long>();
                for (int i = 0; i < classID.Length; i++)
                {
                    temp = new ExamDao().GetExamIDByClassID(classID[i]);
                    if (temp.Count != 0)
                        examID.AddRange(temp);
                }
                examID = (List<long>)examID.Distinct().ToList();

                List<CalendarExamCustom> data = new List<CalendarExamCustom>();
                for (int i = 0; i < examID.Count; i++)
                {
                    var myExamID = examID[i];
                    var obj = db.Exams.Where(m => m.ExamID == myExamID).Select(m => new CalendarExamCustom
                    {
                        Title = m.ExamName,
                        Start_Date = (DateTime)m.StartDay,
                        End_Date = (DateTime)m.EndDay
                    }).FirstOrDefault();
                    if (obj != null)
                        data.Add(obj);
                }

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}