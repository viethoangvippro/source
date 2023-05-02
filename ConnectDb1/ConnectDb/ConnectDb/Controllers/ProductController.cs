using ConnectDb.Data;
using ConnectDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectDb.Controllers
{
    public class ProductController : Controller
    {
        private readonly CategoryDbContext _db;

        public ProductController(CategoryDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.products;
            return View(objList);
        }
    }
}
