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
    public class HanhKhachsController : Controller
    {
        private readonly WebMVC_Hanhkhach_ChuyenbayContext _context;

        public HanhKhachsController(WebMVC_Hanhkhach_ChuyenbayContext context)
        {
            _context = context;
        }

        // GET: HanhKhachs
        public async Task<IActionResult> Index(string searchString)
        {
            var hkQuery = from hk in _context.HanhKhach
                          select hk;

            if (!String.IsNullOrEmpty(searchString))
            {
                hkQuery = hkQuery.Where(hk => hk.HoTen.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            return View(await hkQuery.ToListAsync());
        }
        
        // GET: HanhKhachs
        public async Task<IActionResult> TimKiem(string? ht)
        {
            var danhsach = await _context.ChuyenBay
        .Include(m => m.HanhKhach)
        .Where(predicate: m => m.HanhKhach.HoTen.Contains(ht))

        .ToListAsync();
            if (danhsach == null)
            {
                return NotFound();
            }
            ViewBag.HoTen = ht;
            return View(danhsach);

        }



        // GET: HanhKhachs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HanhKhach == null)
            {
                return NotFound();
            }

            var hanhKhach = await _context.HanhKhach
                .FirstOrDefaultAsync(m => m.MaHanhKhach == id);
            if (hanhKhach == null)
            {
                return NotFound();
            }

            return View(hanhKhach);
        }

        // GET: HanhKhachs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HanhKhachs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHanhKhach,HoTen,SoCMND,SoDT,NoiDen")] HanhKhach hanhKhach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hanhKhach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hanhKhach);
        }

        // GET: HanhKhachs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HanhKhach == null)
            {
                return NotFound();
            }

            var hanhKhach = await _context.HanhKhach.FindAsync(id);
            if (hanhKhach == null)
            {
                return NotFound();
            }
            return View(hanhKhach);
        }

        // POST: HanhKhachs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHanhKhach,HoTen,SoCMND,SoDT,NoiDen")] HanhKhach hanhKhach)
        {
            if (id != hanhKhach.MaHanhKhach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hanhKhach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HanhKhachExists(hanhKhach.MaHanhKhach))
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
            return View(hanhKhach);
        }

        // GET: HanhKhachs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HanhKhach == null)
            {
                return NotFound();
            }

            var hanhKhach = await _context.HanhKhach
                .FirstOrDefaultAsync(m => m.MaHanhKhach == id);
            if (hanhKhach == null)
            {
                return NotFound();
            }

            return View(hanhKhach);
        }

        // POST: HanhKhachs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HanhKhach == null)
            {
                return Problem("Entity set 'WebMVC_Hanhkhach_ChuyenbayContext.HanhKhach'  is null.");
            }
            var hanhKhach = await _context.HanhKhach.FindAsync(id);
            if (hanhKhach != null)
            {
                _context.HanhKhach.Remove(hanhKhach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HanhKhachExists(int id)
        {
          return (_context.HanhKhach?.Any(e => e.MaHanhKhach == id)).GetValueOrDefault();
        }
    }
}
