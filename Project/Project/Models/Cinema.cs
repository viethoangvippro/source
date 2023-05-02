using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "")]
        public string Logo { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Giới thiệu")]
        public string Description { get; set; }
        //Relationship
        public List<Movie> Movies { get; set; }
    }
}
