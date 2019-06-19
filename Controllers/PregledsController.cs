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
    public class PregledsController : Controller
    {
        private readonly HospitalisContext _context;

        public PregledsController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: Pregleds
        public ActionResult Index(String search)
        {
            DateTime datum = DateTime.Now;
            var hospitalisContext = _context.pregledi.Where(p => ((p.Korisnik.ime == search || search == null) 
                                    && (p.termin >= datum && p.termin.Date <= datum.Date.AddDays(7)))).ToList();
            List<Pregled> SortedList = hospitalisContext.OrderBy(o => o.termin).ToList();
            return View(SortedList);
        }

        // GET: Pregleds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregled = await _context.pregledi
                .Include(p => p.Korisnik)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pregled == null)
            {
                return NotFound();
            }

            return View(pregled);
        }

        // GET: Pregleds/Create
        public IActionResult Create()
        {
            List<Doktor> listaDoktora = new List<Doktor>();
            listaDoktora = _context.doktori.ToList();
            ViewBag.lista = listaDoktora;
            return View();
        }

        // POST: Pregleds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,termin, zauzet, KorisnikId")] Pregled pregled)
        {            
            List <Doktor> trazeniDoktor= _context.doktori.Where(p => p.ID == pregled.KorisnikId).ToList();
            pregled.ime = trazeniDoktor.ElementAt(0).ime;
            pregled.prezime = trazeniDoktor.ElementAt(0).prezime;

            if (ModelState.IsValid)
            {
                _context.Add(pregled);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", pregled.KorisnikId);
            return View(pregled);
        }

        // GET: Pregleds/Edit/5
        public async Task<IActionResult> Edit(int? id /*, [Bind("zauzet")] String polje, String kod*/ )
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregled = await _context.pregledi.FindAsync(id);
            if (pregled == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", pregled.KorisnikId);
            return View(pregled);
        }

        // POST: Pregleds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,termin,zauzet,KorisnikId,ime,prezime")] Pregled pregled)
        {

            if (id != pregled.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregled);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PregledExists(pregled.ID))
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
            return View(pregled);
        }

        // GET: Pregleds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregled = await _context.pregledi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pregled == null)
            {
                return NotFound();
            }

            return View(pregled);
        }

        // POST: Pregleds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pregled = await _context.pregledi.FindAsync(id);
            _context.pregledi.Remove(pregled);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PregledExists(int id)
        {
            return _context.pregledi.Any(e => e.ID == id);
        }
    }
}
