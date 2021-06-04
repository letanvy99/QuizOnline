namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Question()
        {
            User_Answers = new HashSet<User_Answers>();
        }

        [Key]
        public long UserQuestionID { get; set; }

        public long UserClassExamID { get; set; }

        public long QuestionID { get; set; }

        public virtual Question Question { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Answers> User_Answers { get; set; }

        public virtual User_Class_Exams User_Class_Exams { get; set; }
    }
}
