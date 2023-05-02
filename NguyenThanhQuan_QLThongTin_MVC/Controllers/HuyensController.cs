using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenThanhQuan_QLThongTin_MVC.Data;
using NguyenThanhQuan_QLThongTin_MVC.Models;
using NguyenThanhQuan_QLThongTin_MVC.ViewModel;

namespace NguyenThanhQuan_QLThongTin_MVC.Controllers
{
    public class HuyensController : Controller
    {
        private readonly QLThongTinDbContext _context;

        public HuyensController(QLThongTinDbContext context)
        {
            _context = context;
        }

        public IActionResult HuyenTinh(int? id)
        {
            if (id == null || _context.Huyens == null)
            {
                return NotFound();
            }

            var huyen = _context.Huyens.Where(m => m.IdTinh == id);
            if (huyen == null)
            {
                return NotFound();
            }

            return View(huyen);
        }

        // GET: Huyens
        public async Task<IActionResult> Index()
        {
            var qLThongTinDbContext = _context.Huyens.Include(h => h.Tinh);
            return View(await qLThongTinDbContext.ToListAsync());
        }

        // GET: Huyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.Huyens
                .Include(h => h.Tinh)
                .FirstOrDefaultAsync(m => m.IdHuyen == id);
            if (huyen == null)
            {
                return NotFound();
            }

            return View(huyen);
        }

        // GET: Huyens/Create
        public IActionResult Create()
        {
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh");
            return View();
        }

        // POST: Huyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HuyenViewModel huyenVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Huyen
                {
                    TenHuyen = huyenVM.TenHuyen,
                    IdTinh = huyenVM.IdTinh
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh", huyenVM.IdTinh);
            return View(huyenVM);
        }

        // GET: Huyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.Huyens.FindAsync(id);
            if (huyen == null)
            {
                return NotFound();
            }
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh", huyen.IdTinh);
            return View(huyen);
        }

        // POST: Huyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Huyen huyen)
        {
            if (id != huyen.IdHuyen)
            {
                return NotFound();
            }

            if (huyen.IdTinh.ToString() != null && huyen.TenHuyen != null)
            {
                try
                {
                    _context.Update(huyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuyenExists(huyen.IdHuyen))
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
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh", huyen.IdTinh);
            return View(huyen);
        }

        // GET: Huyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.Huyens
                .Include(h => h.Tinh)
                .FirstOrDefaultAsync(m => m.IdHuyen == id);
            if (huyen == null)
            {
                return NotFound();
            }

            return View(huyen);
        }

        // POST: Huyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Huyens == null)
            {
                return Problem("Entity set 'QLThongTinDbContext.Huyens'  is null.");
            }
            var huyen = await _context.Huyens.FindAsync(id);
            if (huyen != null)
            {
                _context.Huyens.Remove(huyen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuyenExists(int id)
        {
          return _context.Huyens.Any(e => e.IdHuyen == id);
        }
    }
}
