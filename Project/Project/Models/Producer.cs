using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Tên")]
        public string FullName { get; set; }
        [Display(Name = "")]
        public string Picture { get; set; }
        [Display(Name = "Giới thiệu")]
        public string Description { get; set; }
        //Relationship
        public List<Movie> Movies { get; set; }
    }
}
