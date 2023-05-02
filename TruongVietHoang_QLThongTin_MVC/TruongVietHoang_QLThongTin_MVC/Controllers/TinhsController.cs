using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruongVietHoang_QLThongTin_MVC.Data;
using TruongVietHoang_QLThongTin_MVC.Models;

namespace TruongVietHoang_QLThongTin_MVC.Controllers
{
    public class TinhsController : Controller
    {
        private readonly CdbContext _context;

        public TinhsController(CdbContext context)
        {
            _context = context;
        }

        // GET: Tinhs
        public async Task<IActionResult> Index()
        {
              return View(await _context.tinhs.ToListAsync());
        }

        // GET: Tinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tinhs == null)
            {
                return NotFound();
            }

            var tinh = await _context.tinhs
                .FirstOrDefaultAsync(m => m.id == id);
            if (tinh == null)
            {
                return NotFound();
            }

            return View(tinh);
        }

        // GET: Tinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,TenTinh")] Tinh tinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinh);
        }

        // GET: Tinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tinhs == null)
            {
                return NotFound();
            }

            var tinh = await _context.tinhs.FindAsync(id);
            if (tinh == null)
            {
                return NotFound();
            }
            return View(tinh);
        }

        // POST: Tinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,TenTinh")] Tinh tinh)
        {
            if (id != tinh.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhExists(tinh.id))
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
            return View(tinh);
        }

        // GET: Tinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tinhs == null)
            {
                return NotFound();
            }

            var tinh = await _context.tinhs
                .FirstOrDefaultAsync(m => m.id == id);
            if (tinh == null)
            {
                return NotFound();
            }

            return View(tinh);
        }

        // POST: Tinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tinhs == null)
            {
                return Problem("Entity set 'CdbContext.tinhs'  is null.");
            }
            var tinh = await _context.tinhs.FindAsync(id);
            if (tinh != null)
            {
                _context.tinhs.Remove(tinh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinhExists(int id)
        {
          return _context.tinhs.Any(e => e.id == id);
        }
    }
}
