using Microsoft.AspNetCore.Hosting.Server;
using System.ComponentModel.DataAnnotations;

namespace ConnectDB2.Models
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
