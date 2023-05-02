using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class ProController : Controller
    {
        private readonly QLThongTinDbContext _context;

        public ProController(QLThongTinDbContext context)
        {
            _context = context;
        }

        public IActionResult CatPro(int? id)
        {
            if (id == null || _context.Pros == null)
            {
                return NotFound();
            }

            var pro = _context.Pros.Where(m => m.IdCat == id);
            if (pro == null)
            {
                return NotFound();
            }
           /* if (!String.IsNullOrEmpty(key))
            {
                pro = pro.Where(h => h.NamePro.Contains(key));
            }*/

            return View(pro);
        }
        

        // GET: Pros
        public async Task<IActionResult> Index()
        {
            var qLThongTinDbContext = _context.Pros.Include(h => h.Cat);
            return View(await qLThongTinDbContext.ToListAsync());
        }

        // GET: Pros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pros == null)
            {
                return NotFound();
            }

            var pro = await _context.Pros
                .Include(h => h.Cat)
                .FirstOrDefaultAsync(m => m.IdPro == id);
            if (pro == null)
            {
                return NotFound();
            }

            return View(pro);
        }

        public async Task<IActionResult> DetailsHome(int? id)
        {
            if (id == null || _context.Pros == null)
            {
                return NotFound();
            }

            var pro = await _context.Pros
                .Include(h => h.Cat)
                .FirstOrDefaultAsync(m => m.IdPro == id);
            if (pro == null)
            {
                return NotFound();
            }

            return View(pro);
        }

        // GET: Pros/Create
        public IActionResult Create()
        {
            ViewData["IdCat"] = new SelectList(_context.Cats, "Id", "Tên danh mục");
            return View();
        }

        // POST: Pros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProViewModel proVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Pro
                {
                    NamePro = proVM.NamePro,
                    Description = proVM.Description,
                    Img = proVM.Img,
                    Price = proVM.Price,
                    IdCat = proVM.IdCat
                    
                }) ;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCat"] = new SelectList(_context.Cats, "Id", "NameCat", proVM.IdCat);
            return View(proVM);
        }

        // GET: Pros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pros == null)
            {
                return NotFound();
            }

            var pro = await _context.Pros.FindAsync(id);
            if (pro == null)
            {
                return NotFound();
            }
            ViewData["IdCat"] = new SelectList(_context.Cats, "Id", "NameCat", pro.IdCat);
            return View(pro);
        }

        // POST: Pros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pro pro)
        {
            if (id != pro.IdPro)
            {
                return NotFound();
            }

            if (pro.IdCat.ToString() != null && pro.NamePro != null)
            {
                try
                {
                    _context.Update(pro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuyenExists(pro.IdPro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTinh"] = new SelectList(_context.Cats, "Id", "NameCat", pro.IdCat);
            return View(pro);
        }

        // GET: Pros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pros == null)
            {
                return NotFound();
            }

            var pro = await _context.Pros
                .Include(h => h.Cat)
                .FirstOrDefaultAsync(m => m.IdPro == id);
            if (pro == null)
            {
                return NotFound();
            }

            return View(pro);
        }

        // POST: Pros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pros == null)
            {
                return Problem("Entity set 'QLThongTinDbContext.Pros'  is null.");
            }
            var pro = await _context.Pros.FindAsync(id);
            if (pro != null)
            {
                _context.Pros.Remove(pro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string? key = "")
        {
            if(key == null || key == "")
            {
                var qlThongTinDBContext = _context.Pros.Include(h => h.Cat);
                return View(await qlThongTinDBContext.ToListAsync());
            }
            else
            {
                IEnumerable < Pro > isPro = _context.Pros.Where(h => h.NamePro.Contains(key));
                return View(isPro);
            }
        }


        private bool HuyenExists(int id)
        {
            return _context.Pros.Any(e => e.IdPro == id);
        }
    }
}
