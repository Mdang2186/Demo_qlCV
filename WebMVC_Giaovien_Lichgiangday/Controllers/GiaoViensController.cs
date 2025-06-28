using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC_GiaoVien_LichGiangDay.Data;
using WebMVC_GiaoVien_LichGiangDay.Models;

namespace WebMVC_GiaoVien_LichGiangDay.Controllers
{
    public class GiaoViensController : Controller
    {
        private readonly WebMVC_GiaoVien_LichGiangDayContext _context;

        public GiaoViensController(WebMVC_GiaoVien_LichGiangDayContext context)
        {
            _context = context;
        }

        // GET: GiaoViens
        public async Task<IActionResult> Index(string searchString)
        {
            var gvQuery = from g in _context.GiaoVien
                          select g;

            // If search string provided, filter by HoTen
            if (!String.IsNullOrEmpty(searchString))
            {
                gvQuery = gvQuery.Where(g => g.HoTen.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(await gvQuery.ToListAsync());
        }

        // GET: GiaoViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GiaoVien == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoVien
                .FirstOrDefaultAsync(m => m.MaGV == id);
            if (giaoVien == null)
            {
                return NotFound();
            }

            return View(giaoVien);
        }

        // GET: GiaoViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiaoViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGV,HoTen,BoMon,SoDienThoai")] GiaoVien giaoVien)
        {

            if (_context.GiaoVien.Any(g => g.MaGV == giaoVien.MaGV))
            {
                ModelState.AddModelError("MaGV", "Mã giáo viên đã tồn tại.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(giaoVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(giaoVien);
        }

        // GET: GiaoViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GiaoVien == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoVien.FindAsync(id);
            if (giaoVien == null)
            {
                return NotFound();
            }
            return View(giaoVien);
        }

        // POST: GiaoViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGV,HoTen,BoMon,SoDienThoai")] GiaoVien giaoVien)
        {
            if (id != giaoVien.MaGV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaoVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaoVienExists(giaoVien.MaGV))
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
            return View(giaoVien);
        }

        // GET: GiaoViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GiaoVien == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoVien
                .FirstOrDefaultAsync(m => m.MaGV == id);
            if (giaoVien == null)
            {
                return NotFound();
            }

            return View(giaoVien);
        }

        // POST: GiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GiaoVien == null)
            {
                return Problem("Entity set 'WebMVC_GiaoVien_LichGiangDayContext.GiaoVien'  is null.");
            }
            var giaoVien = await _context.GiaoVien.FindAsync(id);
            if (giaoVien != null)
            {
                _context.GiaoVien.Remove(giaoVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaoVienExists(int id)
        {
          return (_context.GiaoVien?.Any(e => e.MaGV == id)).GetValueOrDefault();
        }
    }
}
