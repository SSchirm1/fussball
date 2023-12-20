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
    public class SpillersController : Controller
    {
        private readonly fussballContext _context;

        public SpillersController(fussballContext context)
        {
            _context = context;
        }

        // GET: Spillers
        public async Task<IActionResult> Index()
        {
              return _context.Spiller != null ? 
                          View(await _context.Spiller.ToListAsync()) :
                          Problem("Entity set 'fussballContext.Spiller'  is null.");
        }

        // GET: Spillers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spiller == null)
            {
                return NotFound();
            }

            var spiller = await _context.Spiller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spiller == null)
            {
                return NotFound();
            }

            return View(spiller);
        }

        // GET: Spillers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spillers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fornavn,Etternavn")] Spiller spiller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spiller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spiller);
        }

        // GET: Spillers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spiller == null)
            {
                return NotFound();
            }

            var spiller = await _context.Spiller.FindAsync(id);
            if (spiller == null)
            {
                return NotFound();
            }
            return View(spiller);
        }

        // POST: Spillers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fornavn,Etternavn")] Spiller spiller)
        {
            if (id != spiller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spiller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpillerExists(spiller.Id))
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
            return View(spiller);
        }

        // GET: Spillers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spiller == null)
            {
                return NotFound();
            }

            var spiller = await _context.Spiller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spiller == null)
            {
                return NotFound();
            }

            return View(spiller);
        }

        // POST: Spillers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spiller == null)
            {
                return Problem("Entity set 'fussballContext.Spiller'  is null.");
            }
            var spiller = await _context.Spiller.FindAsync(id);
            if (spiller != null)
            {
                _context.Spiller.Remove(spiller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpillerExists(int id)
        {
          return (_context.Spiller?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
