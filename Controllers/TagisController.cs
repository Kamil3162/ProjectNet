using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplikacja2.Models;

namespace Aplikacja2.Controllers
{
    public class TagisController : Controller
    {
        private readonly AspbazaContext _context;

        public TagisController(AspbazaContext context)
        {
            _context = context;
        }

        // GET: Tagis
        public async Task<IActionResult> Index()
        {
              return _context.Tagis != null ? 
                          View(await _context.Tagis.ToListAsync()) :
                          Problem("Entity set 'AspbazaContext.Tagis'  is null.");
        }

        // GET: Tagis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tagis == null)
            {
                return NotFound();
            }

            var tagi = await _context.Tagis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagi == null)
            {
                return NotFound();
            }

            return View(tagi);
        }

        // GET: Tagis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tagis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] Tagi tagi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tagi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tagi);
        }

        // GET: Tagis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tagis == null)
            {
                return NotFound();
            }

            var tagi = await _context.Tagis.FindAsync(id);
            if (tagi == null)
            {
                return NotFound();
            }
            return View(tagi);
        }

        // POST: Tagis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] Tagi tagi)
        {
            if (id != tagi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tagi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagiExists(tagi.Id))
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
            return View(tagi);
        }

        // GET: Tagis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tagis == null)
            {
                return NotFound();
            }

            var tagi = await _context.Tagis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagi == null)
            {
                return NotFound();
            }

            return View(tagi);
        }

        // POST: Tagis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tagis == null)
            {
                return Problem("Entity set 'AspbazaContext.Tagis'  is null.");
            }
            var tagi = await _context.Tagis.FindAsync(id);
            if (tagi != null)
            {
                _context.Tagis.Remove(tagi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagiExists(int id)
        {
          return (_context.Tagis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
