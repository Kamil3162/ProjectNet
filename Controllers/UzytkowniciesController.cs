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
    public class UzytkowniciesController : Controller
    {
        private readonly AspbazaContext _context;

        public UzytkowniciesController(AspbazaContext context)
        {
            _context = context;
        }

        // GET: Uzytkownicies
        public async Task<IActionResult> Index()
        {
              return _context.Uzytkownicies != null ? 
                          View(await _context.Uzytkownicies.ToListAsync()) :
                          Problem("Entity set 'AspbazaContext.Uzytkownicies'  is null.");
        }

        // GET: Uzytkownicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uzytkownicies == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.Uzytkownicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return View(uzytkownicy);
        }

        // GET: Uzytkownicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Email,Haslo")] Uzytkownicy uzytkownicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownicy);
        }

        // GET: Uzytkownicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uzytkownicies == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.Uzytkownicies.FindAsync(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }
            return View(uzytkownicy);
        }

        // POST: Uzytkownicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Email,Haslo")] Uzytkownicy uzytkownicy)
        {
            if (id != uzytkownicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownicyExists(uzytkownicy.Id))
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
            return View(uzytkownicy);
        }

        // GET: Uzytkownicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uzytkownicies == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.Uzytkownicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return View(uzytkownicy);
        }

        // POST: Uzytkownicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uzytkownicies == null)
            {
                return Problem("Entity set 'AspbazaContext.Uzytkownicies'  is null.");
            }
            var uzytkownicy = await _context.Uzytkownicies.FindAsync(id);
            if (uzytkownicy != null)
            {
                _context.Uzytkownicies.Remove(uzytkownicy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownicyExists(int id)
        {
          return (_context.Uzytkownicies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
