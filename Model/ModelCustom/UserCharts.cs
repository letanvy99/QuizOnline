using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class UserCharts
    {
        public string date { get; set; }
        public long countRegister { get; set; }
        public UserCharts()
        {
        }

        public UserCharts(string date, long countRegister)
        {
            this.date = date;
            this.countRegister = countRegister;
        }
    }
}
