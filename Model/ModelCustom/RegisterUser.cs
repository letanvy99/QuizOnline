using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class RegisterUser
    {

        [Key]
        public long ID { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 kí tự và tối đa là 20 kí tự.")]
        public string Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Nhập lại mật khẩu không khớp với mật khẩu.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Địa chỉ mail")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ mail")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng địa chỉ mail.")]
        public string Email { get; set; }

    }
}
