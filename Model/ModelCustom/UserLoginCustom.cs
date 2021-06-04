using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class UserLoginCustom
    {
        //[Required(ErrorMessage ="Mời nhập user name")]
        [StringLength(20)]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Mời nhập password")]
        [StringLength(20)]
        public string Password { get; set; }
        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
        public string returnUrl { get; set; }
    }
}
