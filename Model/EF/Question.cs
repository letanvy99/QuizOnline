namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
            Exam_Questions = new HashSet<Exam_Questions>();
            User_Question = new HashSet<User_Question>();
        }

        public long QuestionID { get; set; }

        public long CategoryID { get; set; }

        public long UserID { get; set; }

        public int? LevelQuestion { get; set; }

        public string QuestionContent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteAt { get; set; }

        public long? CreateBy { get; set; }

        public long? UpdateBy { get; set; }

        public int? QuestionTime { get; set; }

        public string Image { get; set; }

        public string Media { get; set; }

        public int? QuestionType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam_Questions> Exam_Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Question> User_Question { get; set; }
    }
}
