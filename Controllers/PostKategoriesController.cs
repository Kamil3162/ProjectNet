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
    public class PostKategoriesController : Controller
    {
        private readonly AspbazaContext _context;

        public PostKategoriesController(AspbazaContext context)
        {
            _context = context;
        }

        // GET: PostKategories
        public async Task<IActionResult> Index()
        {
            var aspbazaContext = _context.PostKategorie.Include(p => p.Kategoria).Include(p => p.Post);
            return View(await aspbazaContext.ToListAsync());
        }

        // GET: PostKategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostKategorie == null)
            {
                return NotFound();
            }

            var postKategorie = await _context.PostKategorie
                .Include(p => p.Kategoria)
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (postKategorie == null)
            {
                return NotFound();
            }

            return View(postKategorie);
        }

        // GET: PostKategories/Create
        public IActionResult Create()
        {
            ViewData["KategoriaId"] = new SelectList(_context.Kategories, "Id", "Id");
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id");
            return View();
        }

        // POST: PostKategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,KategoriaId")] PostKategorie postKategorie)
        {
            Console.WriteLine("test create 1");

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                Console.WriteLine("sprawdzanie modelu isValid");

                _context.Add(postKategorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("test create 3");

            ViewData["KategoriaId"] = new SelectList(_context.Kategories, "Id", "Id", postKategorie.KategoriaId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", postKategorie.PostId);

            Console.WriteLine("test create 2");

            return View(postKategorie);
        }

        // GET: PostKategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostKategorie == null)
            {
                return NotFound();
            }

            var postKategorie = await _context.PostKategorie.FindAsync(id);
            if (postKategorie == null)
            {
                return NotFound();
            }
            ViewData["KategoriaId"] = new SelectList(_context.Kategories, "Id", "Id", postKategorie.KategoriaId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", postKategorie.PostId);
            return View(postKategorie);
        }

        // POST: PostKategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,KategoriaId")] PostKategorie postKategorie)
        {
            if (id != postKategorie.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postKategorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostKategorieExists(postKategorie.PostId))
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
            ViewData["KategoriaId"] = new SelectList(_context.Kategories, "Id", "Id", postKategorie.KategoriaId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", postKategorie.PostId);
            return View(postKategorie);
        }

        // GET: PostKategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostKategorie == null)
            {
                return NotFound();
            }

            var postKategorie = await _context.PostKategorie
                .Include(p => p.Kategoria)
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (postKategorie == null)
            {
                return NotFound();
            }

            return View(postKategorie);
        }

        // POST: PostKategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostKategorie == null)
            {
                return Problem("Entity set 'AspbazaContext.PostKategorie'  is null.");
            }
            var postKategorie = await _context.PostKategorie.FindAsync(id);
            if (postKategorie != null)
            {
                _context.PostKategorie.Remove(postKategorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostKategorieExists(int id)
        {
          return (_context.PostKategorie?.Any(e => e.PostId == id)).GetValueOrDefault();
        }
    }
}
