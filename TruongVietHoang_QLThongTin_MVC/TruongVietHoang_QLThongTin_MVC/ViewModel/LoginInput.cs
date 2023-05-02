using System.ComponentModel.DataAnnotations;

namespace TruongVietHoang_QLThongTin_MVC.ViewModel
{
    public class LoginInput
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật Khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }
    }
}
