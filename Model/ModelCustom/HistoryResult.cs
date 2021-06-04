using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class HistoryResult
    {
        public long UserClassExamID { get; set; }//new
        public string ExamName { get; set; }
        public string ClassName { get; set; }
        public int TimeComplete { get; set; }
        public decimal MaxPoint { get; set; }
        public int QuantityTested { get; set; }
    }
}
