namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answer
    {
        public long AnswerID { get; set; }

        public long QuestionID { get; set; }

        public string AnswerContent { get; set; }

        public bool? IsTrue { get; set; }

        public int? OrderAnswer { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteAt { get; set; }

        public long? CreateBy { get; set; }

        public long? UpdateBy { get; set; }

        public virtual Question Question { get; set; }
    }
}
