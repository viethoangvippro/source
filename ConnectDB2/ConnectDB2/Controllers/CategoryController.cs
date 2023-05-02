using ConnectDB2.Data;
using ConnectDB2.Models;
using Microsoft.AspNetCore.Mvc;
namespace ConnectDb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDbContext _db;

        public CategoryController(CategoryDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.categories;
            return View(objList);
        }
    }
}
