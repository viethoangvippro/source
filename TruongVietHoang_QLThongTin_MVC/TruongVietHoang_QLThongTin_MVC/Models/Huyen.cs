using System.ComponentModel.DataAnnotations;

namespace TruongVietHoang_QLThongTin_MVC.Models
{
    public class Huyen
    {
        [Key]
        public int idHuyen { get; set; }
        public string TenHuyen { get; set; }
        public int idTinh { get;set; }
    }
}
