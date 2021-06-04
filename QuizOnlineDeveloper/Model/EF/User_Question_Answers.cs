namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Question_Answers
    {
        [Key]
        public long UserQuestionAnswersID { get; set; }

        public long UserClassExamID { get; set; }

        public long QuestionID { get; set; }

        [Column(TypeName = "text")]
        public string AnswerID { get; set; }

        public bool? IsRight { get; set; }

        public virtual Question Question { get; set; }

        public virtual User_Class_Exams User_Class_Exams { get; set; }
    }
}
