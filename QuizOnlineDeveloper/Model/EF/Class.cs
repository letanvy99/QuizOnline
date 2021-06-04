namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            Class_Exams = new HashSet<Class_Exams>();
            User_Class = new HashSet<User_Class>();
        }

        public long ClassID { get; set; }

        [StringLength(100)]
        public string ClassName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteAt { get; set; }

        public long? CreateBy { get; set; }

        public long? UpdateBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class_Exams> Class_Exams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Class> User_Class { get; set; }
    }
}
