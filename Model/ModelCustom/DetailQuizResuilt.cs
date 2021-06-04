using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class DetailQuizResuilt
    {
        public string ExamName { get; set; }
        public string ClassName { get; set; }
        public int TimeComplete { get; set; }
        public int MaxPoint { get; set; }
        public int QuantityQuestion { get; set; }
        public long UserQuestionAnswersID { get; set; }
        public long QuestionID { get; set; }
        public long AnswerID { get; set; }
        public bool IsRight { get; set; }
    }
}
