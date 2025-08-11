using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticeMVC.Data;
using PracticeMVC.Models;

namespace PracticeMVC.Controllers
{
    public class hodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public hodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: hods
        public async Task<IActionResult> Index()
        {
            return View(await _context.hod.ToListAsync());
        }

        // GET: hods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hod = await _context.hod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hod == null)
            {
                return NotFound();
            }

            return View(hod);
        }

        // GET: hods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: hods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,Email,PhoneNumber,DateOfJoining,Qualification,Experience,Address")] hod hod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hod);
        }

        // GET: hods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hod = await _context.hod.FindAsync(id);
            if (hod == null)
            {
                return NotFound();
            }
            return View(hod);
        }

        // POST: hods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department,Email,PhoneNumber,DateOfJoining,Qualification,Experience,Address")] hod hod)
        {
            if (id != hod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hodExists(hod.Id))
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
            return View(hod);
        }

        // GET: hods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hod = await _context.hod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hod == null)
            {
                return NotFound();
            }

            return View(hod);
        }

        // POST: hods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hod = await _context.hod.FindAsync(id);
            if (hod != null)
            {
                _context.hod.Remove(hod);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hodExists(int id)
        {
            return _context.hod.Any(e => e.Id == id);
        }
    }
}
