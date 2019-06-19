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
    public class UputnicasController : Controller
    {
        private readonly HospitalisContext _context;

        public UputnicasController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: Uputnicas
        public async Task<IActionResult> Index(String search)
        {
            var hospitalisContext = _context.uputnice.Include(i => i.Korisnik);
            return View(await hospitalisContext.Where(u => u.Korisnik.username == search || search == null).ToListAsync());
        }

        // GET: Uputnicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uputnica = await _context.uputnice
                .Include(u => u.Korisnik)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (uputnica == null)
            {
                return NotFound();
            }

            return View(uputnica);
        }

        // GET: Uputnicas/Create
        public IActionResult Create()
        {
            List<Pacijent> lista = new List<Pacijent>();
            lista = _context.pacijenti.ToList();
            ViewBag.lista = lista;
            return View();
        }

        // POST: Uputnicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("svrha,odrediste,ID,datumIzdavanja,KorisnikId,Odjel")] Uputnica uputnica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uputnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.pacijenti, "ID", "ID", uputnica.KorisnikId);

            return View(uputnica);
        }

        // GET: Uputnicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uputnica = await _context.uputnice.FindAsync(id);
            if (uputnica == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", uputnica.KorisnikId);

            return View(uputnica);
        }

        // POST: Uputnicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("svrha,odrediste,ID,datumIzdavanja,KorisnikId")] Uputnica uputnica)
        {
            if (id != uputnica.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uputnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UputnicaExists(uputnica.ID))
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
            ViewData["KorisnikId"] = new SelectList(_context.korisnici, "ID", "ID", uputnica.KorisnikId);

            return View(uputnica);
        }

        // GET: Uputnicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uputnica = await _context.uputnice
                .Include(u => u.Korisnik)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (uputnica == null)
            {
                return NotFound();
            }

            return View(uputnica);
        }

        // POST: Uputnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uputnica = await _context.uputnice.FindAsync(id);
            _context.uputnice.Remove(uputnica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UputnicaExists(int id)
        {
            return _context.uputnice.Any(e => e.ID == id);
        }
    }
}
