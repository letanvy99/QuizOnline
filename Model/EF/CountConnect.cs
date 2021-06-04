namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CountConnect")]
    public partial class CountConnect
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime dateConnect { get; set; }

        public long countView { get; set; }
    }
}
