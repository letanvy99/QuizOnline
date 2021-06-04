using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelCustom
{
    public class ContactToAdmin
    {
        [Display(Name = "Họ & Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn.", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ mail của bạn")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ mail của bạn.", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng địa chỉ mail.")]
        public string Email { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề Email.", AllowEmptyStrings = false)]
        public string Subject { get; set; }
        [Display(Name = "Tin nhắn")]
        [Required(ErrorMessage = "Vui lòng tin nhắn của bản cho chúng tôi.", AllowEmptyStrings = false)]
        public string Content { get; set; }
    }
}
