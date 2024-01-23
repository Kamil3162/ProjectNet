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
    public class KomentarzesController : Controller
    {
        private readonly AspbazaContext _context;

        public KomentarzesController(AspbazaContext context)
        {
            _context = context;
        }

        // GET: Komentarzes
        public async Task<IActionResult> Index()
        {
            var aspbazaContext = _context.Komentarzes.Include(k => k.Post).Include(k => k.Uzytkownik);
            return View(await aspbazaContext.ToListAsync());
        }

        // GET: Komentarzes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Komentarzes == null)
            {
                return NotFound();
            }

            var komentarze = await _context.Komentarzes
                .Include(k => k.Post)
                .Include(k => k.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarze == null)
            {
                return NotFound();
            }

            return View(komentarze);
        }

        // GET: Komentarzes/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id");
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownicies, "Id", "Id");
            return View();
        }

        // POST: Komentarzes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tresc,UzytkownikId,PostId")] Komentarze komentarze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komentarze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", komentarze.PostId);
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownicies, "Id", "Id", komentarze.UzytkownikId);
            return View(komentarze);
        }

        // GET: Komentarzes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Komentarzes == null)
            {
                return NotFound();
            }

            var komentarze = await _context.Komentarzes.FindAsync(id);
            if (komentarze == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", komentarze.PostId);
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownicies, "Id", "Id", komentarze.UzytkownikId);
            return View(komentarze);
        }

        // POST: Komentarzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tresc,UzytkownikId,PostId")] Komentarze komentarze)
        {
            if (id != komentarze.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komentarze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomentarzeExists(komentarze.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", komentarze.PostId);
            ViewData["UzytkownikId"] = new SelectList(_context.Uzytkownicies, "Id", "Id", komentarze.UzytkownikId);
            return View(komentarze);
        }

        // GET: Komentarzes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Komentarzes == null)
            {
                return NotFound();
            }

            var komentarze = await _context.Komentarzes
                .Include(k => k.Post)
                .Include(k => k.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarze == null)
            {
                return NotFound();
            }

            return View(komentarze);
        }

        // POST: Komentarzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Komentarzes == null)
            {
                return Problem("Entity set 'AspbazaContext.Komentarzes'  is null.");
            }
            var komentarze = await _context.Komentarzes.FindAsync(id);
            if (komentarze != null)
            {
                _context.Komentarzes.Remove(komentarze);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomentarzeExists(int id)
        {
          return (_context.Komentarzes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
