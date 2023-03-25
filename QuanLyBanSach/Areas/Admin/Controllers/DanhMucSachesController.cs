﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyBanSach.Models;

namespace QuanLyBanSach.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucSachesController : Controller
    {
        private readonly QlbanSachContext _context;

        public DanhMucSachesController(QlbanSachContext context)
        {
            _context = context;
        }

        // GET: Admin/DanhMucSaches
        public async Task<IActionResult> Index()
        {
              return _context.DanhMucSaches != null ? 
                          View(await _context.DanhMucSaches.ToListAsync()) :
                          Problem("Entity set 'QlbanSachContext.DanhMucSaches'  is null.");
        }

        // GET: Admin/DanhMucSaches/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhMucSaches == null)
            {
                return NotFound();
            }

            var danhMucSach = await _context.DanhMucSaches
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMucSach == null)
            {
                return NotFound();
            }

            return View(danhMucSach);
        }

        // GET: Admin/DanhMucSaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDm,TenDm")] DanhMucSach danhMucSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucSach);
        }

        // GET: Admin/DanhMucSaches/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DanhMucSaches == null)
            {
                return NotFound();
            }

            var danhMucSach = await _context.DanhMucSaches.FindAsync(id);
            if (danhMucSach == null)
            {
                return NotFound();
            }
            return View(danhMucSach);
        }

        // POST: Admin/DanhMucSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDm,TenDm")] DanhMucSach danhMucSach)
        {
            if (id != danhMucSach.MaDm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucSachExists(danhMucSach.MaDm))
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
            return View(danhMucSach);
        }

        // GET: Admin/DanhMucSaches/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DanhMucSaches == null)
            {
                return NotFound();
            }

            var danhMucSach = await _context.DanhMucSaches
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMucSach == null)
            {
                return NotFound();
            }

            return View(danhMucSach);
        }

        // POST: Admin/DanhMucSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DanhMucSaches == null)
            {
                return Problem("Entity set 'QlbanSachContext.DanhMucSaches'  is null.");
            }
            var danhMucSach = await _context.DanhMucSaches.FindAsync(id);
            if (danhMucSach != null)
            {
                _context.DanhMucSaches.Remove(danhMucSach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucSachExists(string id)
        {
          return (_context.DanhMucSaches?.Any(e => e.MaDm == id)).GetValueOrDefault();
        }
    }
}