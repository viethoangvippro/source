using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "")]
        [Required(ErrorMessage = "Hình ảnh bắt buộc")]
        public string Picture { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Họ tên bắt buộc")]
        [StringLength(50,MinimumLength = 2, ErrorMessage ="Họ tên ít nhất 2 chữ")]
        public string FullName { get; set; }

        [Display(Name = "Giới thiệu")]
        [Required(ErrorMessage = "Giới thiệu bắt buộc")]
        public string Description { get; set; }
        //Relationship
        public List<Actor_Movie> Actors_Movies { get; set; }
}
}
