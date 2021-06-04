using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuizOnlineDeveloper
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //URL Tạo Khóa Học
            routes.MapRoute(
                name: "taokhoahoc",
                url: "tao-khoa-hoc",
                defaults: new { controller = "CreateClass", action = "Create", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );

            //URL Khóa học của tôi
            routes.MapRoute(
                name: "khoahoccuatoi",
                url: "khoa-hoc-cua-toi",
                defaults: new { controller = "Classmanagerment", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );

            //URL Khóa học tôi tham gia
            routes.MapRoute(
                name: "khoahoc",
                url: "khoa-hoc",
                defaults: new { controller = "Classmanagerment", action = "MyClass", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );

            //URL Chi Tiết Khóa Học
            routes.MapRoute(
                name: "chitietkhoahoc",
                url: "khoa-hoc/khoa-hoc-{metatitle}-{ClassId}",
                defaults: new { controller = "Classmanagerment", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );

            //URL Edit Khóa học
            routes.MapRoute(
                name: "editkhoahoc",
                url: "khoa-hoc/khoa-hoc-{metatitle}-{classId}/chinh-sua",
                defaults: new { controller = "Classmanagerment", action = "Edit", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );

            //URL Tạo Topic
            routes.MapRoute(
                name: "taotopic",
                url: "topic/tao-topic",
                defaults: new { controller = "Bank", action = "CreateBank", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );

            //URL Index Topic
            routes.MapRoute(
                name: "topic",
                url: "ngan-hang-cua-toi",
                defaults: new { controller = "Bank", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );

            // URL Tạo Câu Hỏi
            routes.MapRoute(
                name: "tao-cau-hoi",
                url: "topic/tao-cau-hoi",
                defaults: new { controller = "Questions", action = "Create", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Tạo Câu Hỏi bằng excel
            routes.MapRoute(
                name: "importexcel",
                url: "topic/import-cau-hoi-bang-excel",
                defaults: new { controller = "Questions", action = "List", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Tạo bài kiểm tra
            routes.MapRoute(
                name: "tao-bai-kiem-tra",
                url: "kiem-tra/tao-bai-kiem-tra",
                defaults: new { controller = "CreateQuiz", action = "Create", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL List bài kiểm tra
            routes.MapRoute(
                name: "bai-kiem-tra",
                url: "kiem-tra",
                defaults: new { controller = "Exam", action = "List", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URLkiểm tra
            routes.MapRoute(
                name: "thuc-hien-bai-kiem-tra",
                url: "bai-thi/{metatitle}",
                defaults: new { controller = "AttemptQuiz", action = "Attempt", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Lịch
            routes.MapRoute(
                name: "lich",
                url: "lich-cua-toi",
                defaults: new { controller = "Calendar", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL lịch sử làm bài
            routes.MapRoute(
                name: "lich su lam bai",
                url: "kiem-tra/lich-su-lam-bai",
                defaults: new { controller = "HistoryReSult", action = "HistoryReSult", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Contact
            routes.MapRoute(
                name: "contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "ContactUS", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Thông Tin cá nhân
            routes.MapRoute(
                name: "info",
                url: "thong-tin-ca-nhan",
                defaults: new { controller = "UpdateUser", action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL login
            routes.MapRoute(
                name: "login",
                url: "dang-nhap",
                defaults: new { controller = "Login", action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Quên mật khẩu
            routes.MapRoute(
                name: "reset-pass",
                url: "quen-mat-khau",
                defaults: new { controller = "Login", action = "ResetPassword", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URLXác nhận mật khẩu
            routes.MapRoute(
                name: "confirm-reset-pass",
                url: "quen-mat-khau/xac-nhan",
                defaults: new { controller = "Login", action = "ConfirmResetPassword", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Đăng kí
            routes.MapRoute(
                name: "register",
                url: "dang-ky",
                defaults: new { controller = "Register", action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );

            // URL Xác nhận đăng kí
            routes.MapRoute(
                name: "confim register",
                url: "dang-ky/xac-nhan",
                defaults: new { controller = "Register", action = "confirm", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );


            // URLTrang chủ
            routes.MapRoute(
                name: "trangchu",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }
            );





            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuizOnlineDeveloper.Controllers" }

            );//.DataTokens.Add("area", "Admin");
        }
    }
}
