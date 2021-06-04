using Model.Common;
using Model.Dao;
using Model.EF;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class QuestionsController : BaseController
    {
        // GET: Questions

        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public ActionResult Create()
        {
            var session = (UserLogin)Session[new CommonConstant().USER_SESSION];
            // get ID to get Category ID
            var categoryList = new ExamDao().getTypeName(session.UserID);
            ViewBag.categoryList = categoryList;
            return View();
        }



        [Authorize(Roles = "Admin, User")]
        //[ValidateInput(false)]
        [HttpPost]
        //public ActionResult Create(Question[] answerArray)
        public ActionResult Create(Dictionary<string, object>[] answerArray, string editor_data,
            string finder_data, long category_id, int level_question)
        {
            //get userID from Sesstion
            var session = (UserLogin)Session[new CommonConstant().USER_SESSION];
            //intinitial object
            var obj = new QuestionDAO();

            //check redunant question content
            var serviceQuestion = new CheckQuestion();
            var listExistQuestion = new QuestionDAO().GetQuestionContentByUserID(session.UserID);
            if (!serviceQuestion.CheckRedunantQuestion(editor_data, listExistQuestion))
            {
                //check type of questions
                var type = new QuestionDAO().CheckQuestionType(answerArray);
                if (type == 0 || type == 1)
                {
                    // add new question => return QuestionID
                    var questionID = obj.AddQuestion(category_id, session.UserID,
                        level_question, editor_data, finder_data, DateTime.Now, type);
                    long answer;
                    if (questionID > 0 && answerArray.Length > 0)
                    {
                        for (int i = 0; i < answerArray.Length; i++)
                        {
                            answer = obj.AddAnswer(questionID, answerArray[i]["answer"].ToString(), (bool)answerArray[i]["isChecked"]);
                            //var tf = answerArray[i]["answer"];
                            //var tf1 = answerArray[i]["isChecked"];
                        }
                        SetAlert("Thêm câu hỏi thành công!", "success");
                        return Json(questionID, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            SetAlert("Câu hỏi trùng!", "error");
            //return View();
            return Json(session, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult List()
        {
            SetAlert("Vui lòng kéo thả file excel vào ô bên dưới!", "warning");
            return View();
        }


        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult List(HttpPostedFileBase excelfile)
        {
            string path = Server.MapPath("~/Data/ExcelFiles");
            string filePath = string.Empty;
            string extension = string.Empty;
            DataTable dtSheet = new DataTable();
            DataSet ExcelData = new DataSet();
            if (excelfile != null)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(excelfile.FileName);
                extension = Path.GetExtension(excelfile.FileName);
                excelfile.SaveAs(filePath);
            }
            string connectionString = string.Empty;
            switch (extension)
            {
                case ".xls":  // for excel 97-03
                    connectionString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx":  // for excel 97-03
                    connectionString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            connectionString = string.Format(connectionString, filePath);
            using (OleDbConnection connExcel = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmdExcel = new OleDbCommand())
                {
                    using (OleDbDataAdapter oadExcel = new OleDbDataAdapter())
                    {
                        cmdExcel.Connection = connExcel;
                        //Get the name of firstsheet
                        connExcel.Open();
                        DataTable dtExcelShcema;
                        dtExcelShcema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string sheetName = dtExcelShcema.Rows[0]["TABLE_NAME"].ToString();
                        connExcel.Close();

                        //read data from first sheet
                        connExcel.Open();
                        cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";
                        oadExcel.SelectCommand = cmdExcel;
                        oadExcel.Fill(dtSheet);
                        connExcel.Close();
                    }
                }
            }
            ExcelData.Tables.Add(dtSheet);
            return View(ExcelData);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Insert(string[][] data)
        //public ActionResult Insert(Dictionary<string, object>[] data)
        {
            var obj = new QuestionDAO();
            //get userID from Sesstion
            var session = (UserLogin)Session[new CommonConstant().USER_SESSION];

            long questionID;
            for (int i = 0; i < data.Length; i++)
            {
                var type = new QuestionDAO().CheckQuesTionTypeByExcel(data[i]);
                var serviceQuestion = new CheckQuestion();
                var listExistQuestion = new QuestionDAO().GetQuestionContentByUserID(session.UserID);
                if (!serviceQuestion.CheckRedunantQuestion(data[i][2], listExistQuestion))
                {
                    // add new question => return QuestionID
                    questionID = obj.AddQuestion(Convert.ToInt64(data[i][0]), session.UserID,
                       Convert.ToInt32(data[i][1]), data[i][2], data[i][3], DateTime.Now, type);

                    for (int j = 4; j < data[i].Length; j = j + 2)
                    {
                        var answer = obj.AddAnswer(questionID, data[i][j], Convert.ToBoolean(Convert.ToInt32(data[i][j + 1])));
                    }
                }
            }
            SetAlert("Thêm câu hỏi thành công!", "success");
            return Json(session, JsonRequestBehavior.AllowGet);

            //return View();
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult Test()
        {
            return View();
        }
    }
}