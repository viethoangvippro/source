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
    public class HuyensController : Controller
    {
        private readonly CdbContext _context;

        public HuyensController(CdbContext context)
        {
            _context = context;
        }

        // GET: Huyens
        public async Task<IActionResult> Index()
        {
              return View(await _context.huyens.ToListAsync());
        }

        // GET: Huyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.huyens
                .FirstOrDefaultAsync(m => m.idHuyen == id);
            if (huyen == null)
            {
                return NotFound();
            }

            return View(huyen);
        }

        // GET: Huyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Huyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idHuyen,TenHuyen,idTinh")] Huyen huyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(huyen);
        }

        // GET: Huyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.huyens.FindAsync(id);
            if (huyen == null)
            {
                return NotFound();
            }
            return View(huyen);
        }

        // POST: Huyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idHuyen,TenHuyen,idTinh")] Huyen huyen)
        {
            if (id != huyen.idHuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuyenExists(huyen.idHuyen))
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
            return View(huyen);
        }

        // GET: Huyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.huyens
                .FirstOrDefaultAsync(m => m.idHuyen == id);
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
            if (_context.huyens == null)
            {
                return Problem("Entity set 'CdbContext.huyens'  is null.");
            }
            var huyen = await _context.huyens.FindAsync(id);
            if (huyen != null)
            {
                _context.huyens.Remove(huyen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuyenExists(int id)
        {
          return _context.huyens.Any(e => e.idHuyen == id);
        }
    }
}
