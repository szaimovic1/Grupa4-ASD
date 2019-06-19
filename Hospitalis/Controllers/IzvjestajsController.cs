using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalisOOAD.Models;

namespace HospitalisOOAD.Controllers
{
    public class IzvjestajsController : Controller
    {
        private readonly HospitalisContext _context;

        public IzvjestajsController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: Izvjestajs
        public async Task<IActionResult> Index(String search)
        {
            var hospitalisContext = _context.izvjestaji.Include(i => i.Korisnik);/*.ime == search || search == null*/
            return View(await hospitalisContext.Where(u => u.Korisnik.username == search || search == null).ToListAsync());
        }

        // GET: Izvjestajs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izvjestaj = await _context.izvjestaji
                .Include(i => i.Korisnik)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (izvjestaj == null)
            {
                return NotFound();
            }

            return View(izvjestaj);
        }

        // GET: Izvjestajs/Create
        public IActionResult Create()
        {
            List<Pacijent> lista = new List<Pacijent>();
            lista = _context.pacijenti.ToList();
            ViewBag.lista = lista;
            return View();
        }

        // POST: Izvjestajs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rezultatPregleda,ID,datumIzdavanja,Odjel,KorisnikId")] Izvjestaj izvjestaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(izvjestaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.pacijenti, "ID", "ID", izvjestaj.KorisnikId);
            return View(izvjestaj);
        }

        // GET: Izvjestajs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izvjestaj = await _context.izvjestaji.FindAsync(id);
            if (izvjestaj == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.pacijenti, "ID", "ID", izvjestaj.KorisnikId);

            return View(izvjestaj);
        }

        // POST: Izvjestajs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rezultatPregleda,ID,datumIzdavanja,KorisnikId")] Izvjestaj izvjestaj)
        {
            if (id != izvjestaj.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(izvjestaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IzvjestajExists(izvjestaj.ID))
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
            ViewData["KorisnikId"] = new SelectList(_context.pacijenti, "ID", "ID", izvjestaj.KorisnikId);

            return View(izvjestaj);
        }

        // GET: Izvjestajs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izvjestaj = await _context.izvjestaji
                .Include(i => i.Korisnik)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (izvjestaj == null)
            {
                return NotFound();
            }

            return View(izvjestaj);
        }

        // POST: Izvjestajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var izvjestaj = await _context.izvjestaji.FindAsync(id);
            _context.izvjestaji.Remove(izvjestaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IzvjestajExists(int id)
        {
            return _context.izvjestaji.Any(e => e.ID == id);
        }
    }
}
