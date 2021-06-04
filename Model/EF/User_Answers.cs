namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Answers
    {
        [Key]
        public long UserAnswersID { get; set; }

        public long UserQuestionID { get; set; }

        public long AnswerID { get; set; }

        public bool IsRight { get; set; }

        public virtual User_Question User_Question { get; set; }
    }
}
