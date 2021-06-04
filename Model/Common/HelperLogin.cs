using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.Common
{
    public static class HelperLogin
    {
        public static bool CheckUserLogin()
        {
            var sess = HttpContext.Current.Session[new CommonConstant().USER_SESSION];
            if (sess == null)
                return false;
            return true;
        }
    }
}
