using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class ExamCustom
    {
        public long ExamID { get; set; }
        public string ExamName { get; set; }
        public int ExamTime { get; set; }
        public int QuantityQuestion { get; set; }
        public DateTime StartD { get; set; }
        public DateTime EndD { get; set; }

        public int QuantityEasyQues { get; set; }
        public int QuantityMediumQues { get; set; }
        public int QuantityHardQues { get; set; }
        public long ClassExamID { get; set; }
        public long ExamCategoryID { get; set; }
        public long UserID { get; set; }
    }
}
