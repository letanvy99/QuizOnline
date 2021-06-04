namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam()
        {
            Class_Exams = new HashSet<Class_Exams>();
            Exam_Questions = new HashSet<Exam_Questions>();
        }

        public long ExamID { get; set; }

        [StringLength(250)]
        public string ExamName { get; set; }

        public int ExamTime { get; set; }

        public bool? IsShowResult { get; set; }

        public long ExamCategoryID { get; set; }

        public int? QuantityQuestion { get; set; }

        public int? QuantityTest { get; set; }

        public int? EasyQuestion { get; set; }

        public int? NormalQuestion { get; set; }

        public int? HardQuestion { get; set; }

        [StringLength(10)]
        public string AcceptCode { get; set; }

        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

        public bool? TypeRandom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteAt { get; set; }

        public long? CreateBy { get; set; }

        public long? UpdateBy { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class_Exams> Class_Exams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam_Questions> Exam_Questions { get; set; }
    }
}
