using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class QuestionCustom
    {
        public long QuestionID { get; set; }

        public long CategoryID { get; set; }

        public long UserID { get; set; }

        public int? LevelQuestion { get; set; }

        public string QuestionContent { get; set; }
        public long? ParentID { get; set; }
        public string Typename { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string Image { get; set; }
        public IEnumerable<AnswerCustom> listAnsw { get; set; }
    }
}
