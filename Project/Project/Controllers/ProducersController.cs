using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Controllers
{
    public class ProducersController : Controller
    {
        public readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducer = await _context.Producers.ToListAsync();
            return View(allProducer);
        }
    }
}
