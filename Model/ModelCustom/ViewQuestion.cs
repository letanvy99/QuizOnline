using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class ViewQuestion
    {
        public long QuestionID { get; set; }
        public string QuestionContent { get; set; }
        public int? LevelQuestion { get; set; }
        public long ExamID { get; set; }
        public int? QuestionType { get; set; }
        public string Image { get; set; }
        public List<AnswerxQuestion> Options { get; set; }
    }
    public class AnswerxQuestion
    {
        public long AnswerID { get; set; }
        public string AnswerContent { get; set; }
        public bool Check { get; set; }
        public bool? isTrue { get; set; }
    }
}
