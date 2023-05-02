using System.ComponentModel.DataAnnotations;

namespace TruongVietHoang_QLThongTin_MVC.Models
{
    public class Tinh
    {
        [Key]
        public int id { get; set; }
        public string TenTinh { get; set; }
    }
}
