using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class ChoiceAnswer
    {
        public List<long> answerID { get; set; }
        public long questionID { get; set; }
        public bool isRight { get; set; }
    }
    public class AnswerModel
    {
        public List<long> QNB { get; set; }
        public long UserClassExamID { get; set; }

        public List<ChoiceAnswer> UserChoices { get; set; }
    }
}
