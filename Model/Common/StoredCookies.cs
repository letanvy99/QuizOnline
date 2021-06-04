using Model.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.Common
{
    public class StoredCookies
    {
        public UserLoginCustom GetInfoUserCookies(string username, string password, bool rememberMe)
        {
            if (HttpContext.Current.Request.Cookies["userName"] != null)
            {
                username = HttpContext.Current.Request.Cookies["userName"].Value;
            }
            if (HttpContext.Current.Request.Cookies["password"] != null)
            {
                password = HttpContext.Current.Request.Cookies["password"].Value;
            }
            if (HttpContext.Current.Request.Cookies["userName"] != null &&
                HttpContext.Current.Request.Cookies["password"] != null)
            {
                rememberMe = true;
            }
            var userLoginCustom = new UserLoginCustom { UserName = username, Password = password, RememberMe = rememberMe };
            return userLoginCustom;
        }
        public void NewInfoUserCookies(string username, string password)
        {
            HttpContext.Current.Response.Cookies["userName"].Value = username;
            HttpContext.Current.Response.Cookies["password"].Value = password;
            HttpContext.Current.Response.Cookies["userName"].Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies["password"].Expires = DateTime.Now.AddDays(30);
        }

        //
        public void DeleteInfoUserCookies()
        {
            HttpContext.Current.Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
