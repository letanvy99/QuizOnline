namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRolesMapping")]
    public partial class UserRolesMapping
    {
        public int ID { get; set; }

        public long UserID { get; set; }

        public int RoleID { get; set; }

        public virtual RoleMaster RoleMaster { get; set; }

        public virtual User User { get; set; }
    }
}
