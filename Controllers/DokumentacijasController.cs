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
    public class DokumentacijasController : Controller
    {
        private readonly HospitalisContext _context;

        public DokumentacijasController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: Dokumentacijas
        public async Task<IActionResult> Index()
        {
            var hospitalisContext = _context.dokumentacije.Include(d => d.Korisnik);
            return View(await hospitalisContext.ToListAsync());
        }

        // GET: Dokumentacijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokumentacija = await _context.dokumentacije
                .Include(d => d.Korisnik)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (dokumentacija == null)
            {
                return NotFound();
            }

            return View(dokumentacija);
        }

        // GET: Dokumentacijas/Create
        public IActionResult Create()
        {
            List<String> lista = new List<String>();
            foreach (Pacijent p in _context.pacijenti)
                lista.Add(p.username);


            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID");

            return View();
        }

        // POST: Dokumentacijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,datumIzdavanja,KorisnikId")] Dokumentacija dokumentacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dokumentacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", dokumentacija.KorisnikId);

            return View(dokumentacija);
        }

        // GET: Dokumentacijas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokumentacija = await _context.dokumentacije.FindAsync(id);
            if (dokumentacija == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", dokumentacija.KorisnikId);

            return View(dokumentacija);
        }

        // POST: Dokumentacijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,datumIzdavanja,KorisnikId")] Dokumentacija dokumentacija)
        {
            if (id != dokumentacija.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dokumentacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DokumentacijaExists(dokumentacija.ID))
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
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", dokumentacija.KorisnikId);

            return View(dokumentacija);
        }

        // GET: Dokumentacijas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokumentacija = await _context.dokumentacije
                .Include(d => d.Korisnik)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (dokumentacija == null)
            {
                return NotFound();
            }

            return View(dokumentacija);
        }

        // POST: Dokumentacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dokumentacija = await _context.dokumentacije.FindAsync(id);
            _context.dokumentacije.Remove(dokumentacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DokumentacijaExists(int id)
        {
            return _context.dokumentacije.Any(e => e.ID == id);
        }

    }
}
