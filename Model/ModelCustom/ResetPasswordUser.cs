using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class ResetPasswordUser
    {
        [Required(ErrorMessage = "Hãy nhật mật khẩu mới.", AllowEmptyStrings = false)]
        [Display(Name = "Mật khẩu mới")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 kí tự và tối đa là 20 kí tự.")]
        public string NewPassword { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("NewPassword", ErrorMessage = "Nhập lại mật khẩu không khớp với mật khẩu mới.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ResetCode { get; set; }

    }
}
