namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Class_Exams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class_Exams()
        {
            User_Class_Exams = new HashSet<User_Class_Exams>();
        }

        [Key]
        public long ClassExamID { get; set; }

        public long ClassID { get; set; }

        public long ExamID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteAt { get; set; }

        public virtual Class Class { get; set; }

        public virtual Exam Exam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Class_Exams> User_Class_Exams { get; set; }
    }
}
