using System.ComponentModel.DataAnnotations;
namespace ConnectDB2.Models
{
    public class Category
    {
        [Key]

        public int id { get; set; }
        public string Name { get; set; }

        public string DisplayOrder { get; set; }
    }
}
