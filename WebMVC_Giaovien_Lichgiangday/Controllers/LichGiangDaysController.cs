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
    public class LichGiangDaysController : Controller
    {
        private readonly WebMVC_GiaoVien_LichGiangDayContext _context;

        public LichGiangDaysController(WebMVC_GiaoVien_LichGiangDayContext context)
        {
            _context = context;
        }

        // GET: LichGiangDays
        public async Task<IActionResult> Index()
        {
            var webMVC_GiaoVien_LichGiangDayContext = _context.LichGiangDay.Include(l => l.GiaoVien);
            return View(await webMVC_GiaoVien_LichGiangDayContext.ToListAsync());
        }

        // GET: LichGiangDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LichGiangDay == null)
            {
                return NotFound();
            }

            var lichGiangDay = await _context.LichGiangDay
                .Include(l => l.GiaoVien)
                .FirstOrDefaultAsync(m => m.MaLich == id);
            if (lichGiangDay == null)
            {
                return NotFound();
            }

            return View(lichGiangDay);
        }

        // GET: LichGiangDays/Create
        public IActionResult Create()
        {
            ViewData["MaGV"] = new SelectList(_context.Set<GiaoVien>(), "MaGV", "HoTen");
            return View();
        }

        // POST: LichGiangDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLich,MaGV,TenMonHoc,NgayGiangDay")] LichGiangDay lichGiangDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichGiangDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGV"] = new SelectList(_context.Set<GiaoVien>(), "MaGV", "BoMon", lichGiangDay.MaGV);
            return View(lichGiangDay);
        }

        // GET: LichGiangDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LichGiangDay == null)
            {
                return NotFound();
            }

            var lichGiangDay = await _context.LichGiangDay.FindAsync(id);
            if (lichGiangDay == null)
            {
                return NotFound();
            }
            ViewData["MaGV"] = new SelectList(_context.Set<GiaoVien>(), "MaGV", "HoTen", lichGiangDay.MaGV);
            return View(lichGiangDay);
        }

        // POST: LichGiangDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLich,MaGV,TenMonHoc,NgayGiangDay")] LichGiangDay lichGiangDay)
        {
            if (id != lichGiangDay.MaLich)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichGiangDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichGiangDayExists(lichGiangDay.MaLich))
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
            ViewData["MaGV"] = new SelectList(_context.Set<GiaoVien>(), "MaGV", "BoMon", lichGiangDay.MaGV);
            return View(lichGiangDay);
        }

        // GET: LichGiangDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LichGiangDay == null)
            {
                return NotFound();
            }

            var lichGiangDay = await _context.LichGiangDay
                .Include(l => l.GiaoVien)
                .FirstOrDefaultAsync(m => m.MaLich == id);
            if (lichGiangDay == null)
            {
                return NotFound();
            }

            return View(lichGiangDay);
        }

        // POST: LichGiangDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LichGiangDay == null)
            {
                return Problem("Entity set 'WebMVC_GiaoVien_LichGiangDayContext.LichGiangDay'  is null.");
            }
            var lichGiangDay = await _context.LichGiangDay.FindAsync(id);
            if (lichGiangDay != null)
            {
                _context.LichGiangDay.Remove(lichGiangDay);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichGiangDayExists(int id)
        {
          return (_context.LichGiangDay?.Any(e => e.MaLich == id)).GetValueOrDefault();
        }
        // GET: Chức năng Thống kê chi tiết với tất cả các cột
        public async Task<IActionResult> ThongKe(DateTime? fromDate, DateTime? toDate)
        {
            var lectures = _context.LichGiangDay
               .Include(l => l.GiaoVien)
               .AsQueryable();

            if (fromDate.HasValue)
                lectures = lectures.Where(l => l.NgayGiangDay >= fromDate.Value);
            if (toDate.HasValue)
                lectures = lectures.Where(l => l.NgayGiangDay <= toDate.Value);

            var result = lectures.Select(l => new ThongKeLichViewModel
            {
                MaLich = l.MaLich,
                MaGV = l.MaGV,
                HoTen = l.GiaoVien.HoTen,
                TenMonHoc = l.TenMonHoc,
                NgayGiangDay = l.NgayGiangDay
            });

            ViewData["FromDate"] = fromDate?.ToString("dd-MM-yyyy");
            ViewData["ToDate"] = toDate?.ToString("dd-MM-yyyy");

            return View(await result.ToListAsync());
        }
    }
}
