namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Class
    {
        [Key]
        public long UserClassID { get; set; }

        public long UserID { get; set; }

        public long ClassID { get; set; }

        public virtual Class Class { get; set; }

        public virtual User User { get; set; }
    }
}
