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
    public class AnketasController : Controller
    {
        private readonly HospitalisContext _context;

        public AnketasController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: Anketas
        public ActionResult Index()
        {
            List<Anketa> ankete = _context.ankete.ToList();
            double ocjena = 0;
            foreach (Anketa a in ankete)
                ocjena += a.konacnaOcjena;
            ocjena /= ankete.Count();
            ViewBag.Message = ocjena.ToString();
            return View();
        }

        // GET: Anketas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketa = await _context.ankete
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anketa == null)
            {
                return NotFound();
            }

            return View(anketa);
        }

        // GET: Anketas/Create
        public IActionResult Create()
        {
            List<Doktor> listaDoktora = new List<Doktor>();
            listaDoktora = _context.doktori.ToList();
            ViewBag.lista = listaDoktora;
            return View();
        }

        // POST: Anketas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ocjena1,ocjena2,ocjena3,ocjena4,ocjena5,doktorID")] Anketa anketa)
        {
            if (ModelState.IsValid)
            {
                var konacna = (anketa.ocjena1 + anketa.ocjena2 + anketa.ocjena3 + anketa.ocjena4 + anketa.ocjena5) / 5;
                anketa.konacnaOcjena = konacna;
                _context.Add(anketa);
                await _context.SaveChangesAsync();
                return Redirect("~/IzborniMeni");
            }
            return View(anketa);
        }

        // GET: Anketas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketa = await _context.ankete.FindAsync(id);
            if (anketa == null)
            {
                return NotFound();
            }
            return View(anketa);
        }

        // POST: Anketas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,konacnaOcjena")] Anketa anketa)
        {
            if (id != anketa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anketa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnketaExists(anketa.ID))
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
            return View(anketa);
        }

        // GET: Anketas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketa = await _context.ankete
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anketa == null)
            {
                return NotFound();
            }

            return View(anketa);
        }

        // POST: Anketas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anketa = await _context.ankete.FindAsync(id);
            _context.ankete.Remove(anketa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnketaExists(int id)
        {
            return _context.ankete.Any(e => e.ID == id);
        }
    }
}
