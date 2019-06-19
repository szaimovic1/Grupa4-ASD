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
    public class ReceptsController : Controller
    {
        private readonly HospitalisContext _context;

        public ReceptsController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: Recepts
        public async Task<IActionResult> Index(String search)
        {
            var hospitalisContext = _context.recepti.Include(i => i.Korisnik);
            return View(await hospitalisContext.Where(u => u.Korisnik.username == search || search == null).ToListAsync());
        }

        // GET: Recepts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.recepti
                .Include(r => r.Korisnik)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (recept == null)
            {
                return NotFound();
            }

            return View(recept);
        }

        // GET: Recepts/Create
        public IActionResult Create()
        {
            List<Pacijent> lista = new List<Pacijent>();
            lista = _context.pacijenti.ToList();
            ViewBag.lista = lista;
            return View();

        }

        // POST: Recepts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nazivLijeka,ID,datumIzdavanja,KorisnikId,Odjel")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.pacijenti, "ID", "ID", recept.KorisnikId);

            return View(recept);
        }

        // GET: Recepts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.recepti.FindAsync(id);
            if (recept == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", recept.KorisnikId);

            return View(recept);
        }

        // POST: Recepts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nazivLijeka,ID,datumIzdavanja,KorisnikId")] Recept recept)
        {
            if (id != recept.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recept);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptExists(recept.ID))
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
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", recept.KorisnikId);

            return View(recept);
        }

        // GET: Recepts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.recepti
                .Include(r => r.Korisnik)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (recept == null)
            {
                return NotFound();
            }

            return View(recept);
        }

        // POST: Recepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recept = await _context.recepti.FindAsync(id);
            _context.recepti.Remove(recept);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceptExists(int id)
        {
            return _context.recepti.Any(e => e.ID == id);
        }
    }
}
