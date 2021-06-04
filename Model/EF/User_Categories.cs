namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Categories
    {
        [Key]
        public long UserCategoriesID { get; set; }

        public long CategoryID { get; set; }

        public long UserID { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
