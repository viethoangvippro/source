using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CatController : Controller
    {
        private readonly QLThongTinDbContext _context;

        public CatController(QLThongTinDbContext context)
        {
            _context = context;
        }

        // GET: Cat
        public async Task<IActionResult> IndexTruongVietHoang()
        {
            return View(await _context.Cats.ToListAsync());
        }


        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }

            var tinh = await _context.Cats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tinh == null)
            {
                return NotFound();
            }

            return View(tinh);
        }

        // GET: Cats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CatViewModel catVm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Cat
                {
                    NameCat = catVm.NameCat,
                    Img = catVm.Img
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexTruongVietHoang", "Cat");
            }
            return View(catVm);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Tinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cat cat)
        {
            if (id != cat.Id)
            {
                return NotFound();
            }

            if (cat.NameCat != null)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhExists(cat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("IndexTruongVietHoang", "Cat");
            }
            return View(cat);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cats == null)
            {
                return Problem("Entity set 'QLThongTinDbContext.Cats'  is null.");
            }
            var cat = await _context.Cats.FindAsync(id);
            if (cat != null)
            {
                _context.Cats.Remove(cat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("IndexTruongVietHoang", "Cat");
        }



        private bool TinhExists(int id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }

}

