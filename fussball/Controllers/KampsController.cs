using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fussball.Data;
using fussball.Models;

namespace fussball.Controllers
{
    public class KampsController : Controller
    {
        private readonly fussballContext _context;

        public KampsController(fussballContext context)
        {
            _context = context;
        }

        // GET: Kamps
        public async Task<IActionResult> Index()
        {
              return _context.Kamp != null ? 
                          View(await _context.Kamp.ToListAsync()) :
                          Problem("Entity set 'fussballContext.Kamp'  is null.");
        }

        // GET: Kamps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kamp == null)
            {
                return NotFound();
            }

            var kamp = await _context.Kamp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kamp == null)
            {
                return NotFound();
            }

            return View(kamp);
        }

        // GET: Kamps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kamps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dato")] Kamp kamp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kamp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kamp);
        }

        // GET: Kamps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kamp == null)
            {
                return NotFound();
            }

            var kamp = await _context.Kamp.FindAsync(id);
            if (kamp == null)
            {
                return NotFound();
            }
            return View(kamp);
        }

        // POST: Kamps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dato")] Kamp kamp)
        {
            if (id != kamp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kamp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KampExists(kamp.Id))
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
            return View(kamp);
        }

        // GET: Kamps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kamp == null)
            {
                return NotFound();
            }

            var kamp = await _context.Kamp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kamp == null)
            {
                return NotFound();
            }

            return View(kamp);
        }

        // POST: Kamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kamp == null)
            {
                return Problem("Entity set 'fussballContext.Kamp'  is null.");
            }
            var kamp = await _context.Kamp.FindAsync(id);
            if (kamp != null)
            {
                _context.Kamp.Remove(kamp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KampExists(int id)
        {
          return (_context.Kamp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
