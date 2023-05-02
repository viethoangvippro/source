using System.ComponentModel.DataAnnotations;
namespace ConnectDb.Models
{
    public class Product
    {
        [Key]

        public int id { get; set; }
        public string Name { get; set; }

        public string Quantity { get; set; }

        public int Price { get; set; }

        
    }
}
