using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class ClassServices
    {
        public bool CheckClassCustom(string enrolmentkey, string className)
        {
            if (className == null || className.Length > 100 || enrolmentkey.Length <5 || enrolmentkey.Length > 10)
                return false;
            return true;
        }
        public int CheckUserClass(long userid,string classname)
        {
            var listname = new ClassDao().GetAllNameClass(userid);
            int count = 0;
            for (int i = 0; i < listname.Count(); i++)
            {
                if (listname[i].Contains(classname))
                {
                    count++;
                }
            }
            return count;

        }
    }
}
