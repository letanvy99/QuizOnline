using CommonProject;
using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizOnlineDeveloper.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult ContactUS()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUS(ContactToAdmin model)
        {
            if (ModelState.IsValid)
            {
                sendEmailContacttoAdmin(model);
                ViewBag.Success = "Cảm ơn Bạn đã phản hồi cho chúng tôi! Chúng tôi sẽ sớm liên hệ lại cho bạn !";
                ModelState.Clear();
                ViewBag.Section = "contact";
                return View();
            }
            else
            {
                ViewBag.Error = "error";
            }
            ViewBag.Section = "contact";
            return View(model);
        }
        public void sendEmailContacttoAdmin(ContactToAdmin message)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Asserts/Client/template/ContactAdmin.html"));
            content = content.Replace("{{Day}}", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
            content = content.Replace("{{Subject}}", message.Subject);
            content = content.Replace("{{Name}}", message.Name);
            content = content.Replace("{{Mail}}", message.Email);
            content = content.Replace("{{Content}}", message.Content);
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            new MailHelper().SendMail(toEmail, "Report", content, "Phản hồi của người dùng");
        }
    }
}