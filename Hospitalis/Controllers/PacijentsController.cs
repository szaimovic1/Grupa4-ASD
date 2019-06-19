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
    public class PacijentsController : Controller
    {
        private readonly HospitalisContext _context;

        public PacijentsController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: Pacijents
        public async Task<IActionResult> Index(String search)
        {
            return View(await _context.pacijenti.Where(u => u.ime == search || search == null).ToListAsync());
        }

        // GET: Pacijents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacijent = await _context.pacijenti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pacijent == null)
            {
                return NotFound();
            }

            return View(pacijent);
        }

        // GET: Pacijents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacijents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("jmbg,datumRodjenja,adresaPrebivalista,gradRodjenja,drzavaRodjenja,ID,ime,prezime,email,kontaktTelefon,username,passwordHash,confirmPassword,spol")] Pacijent pacijent)
        {
            List<Korisnik> provjeraUser = _context.korisnici.Where(p => p.username == pacijent.username).ToList();
            if (provjeraUser.Count() != 0)
            {
                ViewBag.Message = "Korisničko ime je već u upotrebi!";
                return View();

            }
            List<Korisnik> provjeraMail = _context.korisnici.Where(p => p.email == pacijent.email).ToList();
            if (provjeraMail.Count() != 0)
            {
                ViewBag.Message = "Email je već u upotrebi!";
                return View();
            }

            if (ModelState.IsValid)
            {
                _context.Add(pacijent);
                await _context.SaveChangesAsync();
                return Redirect("~/IzborniMeni"); ;
            }
            return View();
        }

        // GET: Pacijents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacijent = await _context.pacijenti.FindAsync(id);
            if (pacijent == null)
            {
                return NotFound();
            }
            return View(pacijent);
        }

        // POST: Pacijents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("jmbg,datumRodjenja,adresaPrebivalista,gradRodjenja,drzavaRodjenja,ID,ime,prezime,email,kontaktTelefon,username,passwordHash,spol")] Pacijent pacijent)
        {
            if (id != pacijent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacijent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacijentExists(pacijent.ID))
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
            return View(pacijent);
        }

        // GET: Pacijents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacijent = await _context.pacijenti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pacijent == null)
            {
                return NotFound();
            }

            return View(pacijent);
        }

        // POST: Pacijents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacijent = await _context.pacijenti.FindAsync(id);
            _context.pacijenti.Remove(pacijent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacijentExists(int id)
        {
            return _context.pacijenti.Any(e => e.ID == id);
        }

    }
}
