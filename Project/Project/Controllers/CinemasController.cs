using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Controllers
{
    public class CinemasController : Controller
    {
        public readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _context.Cinemas.ToListAsync();
            return View(allCinemas);
        }
    }
}
