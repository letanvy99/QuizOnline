using System.Web.Mvc;

namespace QuizOnlineDeveloper.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //URL trang chủ admin
            context.MapRoute(
               name: "Admin index",
                url: "admin",
                new {Controller="Home", action = "Index", id = UrlParameter.Optional }
            );

            //URL trang chủ quản lý người dùng
            context.MapRoute(
               name: "quan ly nguoi dung",
                url: "admin/quan-ly-nguoi-dung",
                new { Controller = "ManagerUser", action = "Index", id = UrlParameter.Optional }
            );

            //URL trang chủ chi tiết người dùng
            context.MapRoute(
               name: "AdminindexInfo",
                url: "admin/quan-ly-nguoi-dung/{metatitle}-{id}",
                new { Controller = "ManagerUser", action = "Showinfo", id = UrlParameter.Optional }
            );

            //URL biểu đồ
            context.MapRoute(
              name: "bieu-do-nguoi-dung",
               url: "admin/ban-do-luong-nguoi-dung",
               new { Controller = "UserCharts", action = "Index", id = UrlParameter.Optional }
           );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}


