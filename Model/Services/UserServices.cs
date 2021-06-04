using Model.Dao;
using Model.EF;
using Model.ModelCustom;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Services
{
    public class UserServices
    {
        public bool Login(UserLoginCustom user)
        {
            using(DBCONTENT db = new DBCONTENT())
            {
                var checkPassMD5 = Encryptor.MD5Hash(user.Password);
                var dao = new UserDao();
                return dao.IsUser(user.UserName,checkPassMD5);
            }
        }
    }
}
