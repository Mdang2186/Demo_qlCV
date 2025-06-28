using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC_Hanhkhach_Chuyenbay.Data;
using WebMVC_Hanhkhach_Chuyenbay.Models;

namespace WebMVC_Hanhkhach_Chuyenbay.Controllers
{
    public class ChuyenBaysController : Controller
    {
        private readonly WebMVC_Hanhkhach_ChuyenbayContext _context;

        public ChuyenBaysController(WebMVC_Hanhkhach_ChuyenbayContext context)
        {
            _context = context;
        }

        // GET: ChuyenBays
        public async Task<IActionResult> Index()
        {
            var webMVC_Hanhkhach_ChuyenbayContext = _context.ChuyenBay.Include(c => c.HanhKhach);
            return View(await webMVC_Hanhkhach_ChuyenbayContext.ToListAsync());
        }

        // GET: ChuyenBays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChuyenBay == null)
            {
                return NotFound();
            }

            var chuyenBay = await _context.ChuyenBay
                .Include(c => c.HanhKhach)
                .FirstOrDefaultAsync(m => m.MaChuyenBay == id);
            if (chuyenBay == null)
            {
                return NotFound();
            }

            return View(chuyenBay);
        } 
        // GET: ChuyenBays/Create
        public IActionResult Create()
        {
            ViewData["MaHanhKhach"] = new SelectList(_context.HanhKhach, "MaHanhKhach", "HoTen");
            return View();
        }

        // POST: ChuyenBays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChuyenBay,MaHanhKhach,NgayBay,GiaVe")] ChuyenBay chuyenBay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuyenBay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHanhKhach"] = new SelectList(_context.HanhKhach, "MaHanhKhach", "HoTen", chuyenBay.MaHanhKhach);
            return View(chuyenBay);
        }

        // GET: ChuyenBays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChuyenBay == null)
            {
                return NotFound();
            }

            var chuyenBay = await _context.ChuyenBay.FindAsync(id);
            if (chuyenBay == null)
            {
                return NotFound();
            }
            ViewData["MaHanhKhach"] = new SelectList(_context.HanhKhach, "MaHanhKhach", "HoTen", chuyenBay.MaHanhKhach);
            return View(chuyenBay);
        }

        // POST: ChuyenBays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaChuyenBay,MaHanhKhach,NgayBay,GiaVe")] ChuyenBay chuyenBay)
        {
            if (id != chuyenBay.MaChuyenBay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuyenBay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuyenBayExists(chuyenBay.MaChuyenBay))
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
            ViewData["MaHanhKhach"] = new SelectList(_context.HanhKhach, "MaHanhKhach", "HoTen", chuyenBay.MaHanhKhach);
            return View(chuyenBay);
        }

        // GET: ChuyenBays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChuyenBay == null)
            {
                return NotFound();
            }

            var chuyenBay = await _context.ChuyenBay
                .Include(c => c.HanhKhach)
                .FirstOrDefaultAsync(m => m.MaChuyenBay == id);
            if (chuyenBay == null)
            {
                return NotFound();
            }

            return View(chuyenBay);
        }

        // POST: ChuyenBays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChuyenBay == null)
            {
                return Problem("Entity set 'WebMVC_Hanhkhach_ChuyenbayContext.ChuyenBay'  is null.");
            }
            var chuyenBay = await _context.ChuyenBay.FindAsync(id);
            if (chuyenBay != null)
            {
                _context.ChuyenBay.Remove(chuyenBay);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
        // GET: ChuyenBay/ThongKe
        public async Task<IActionResult> ThongKe(string? search, bool? filterByTotalAmount)
        {
            var query = _context.HanhKhach
                .Include(h => h.ChuyenBays)
                .Select(h => new ThongKeViewModel
                {
                    MaHanhKhach = h.MaHanhKhach,
                    HoTen = h.HoTen,
                    SoCMND = h.SoCMND,
                    NoiDen = h.NoiDen,
                    SoChuyen = h.ChuyenBays.Count(),
                    TongTien = h.ChuyenBays.Sum(c => c.GiaVe)
                });

            if (filterByTotalAmount == true)
            {
                query = query.Where(h => h.TongTien > 20000000);
                ViewData["FilterByTotalAmount"] = true; // Set for view to remember state
            }
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                query = query.Where(h =>
                    h.HoTen.ToLower().Contains(search) ||
                    h.SoCMND.ToLower().Contains(search) ||
                    h.NoiDen.ToLower().Contains(search) ||
                    h.SoChuyen.ToString().Contains(search) ||
                    h.TongTien.ToString().Contains(search)
                );
                ViewData["Search"] = search;
            }
            return View(await query.ToListAsync());
        }

        private bool ChuyenBayExists(int id) => _context.ChuyenBay.Any(e => e.MaChuyenBay == id);
    }
}
