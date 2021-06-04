namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Class_Exams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Class_Exams()
        {
            User_Question = new HashSet<User_Question>();
        }

        [Key]
        public long UserClassExamID { get; set; }

        public long UserID { get; set; }

        public long ClassExamID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateAt { get; set; }

        public int? TimeComplete { get; set; }

        public decimal? MaxPoint { get; set; }

        public int? QuantityTested { get; set; }

        public DateTime startExam { get; set; }

        public virtual Class_Exams Class_Exams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Question> User_Question { get; set; }

        public virtual User User { get; set; }
    }
}
