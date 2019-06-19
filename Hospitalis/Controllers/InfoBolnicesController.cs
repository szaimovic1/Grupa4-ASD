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
    public class InfoBolnicesController : Controller
    {
        private readonly HospitalisContext _context;

        public InfoBolnicesController(HospitalisContext context)
        {
            _context = context;
        }

        // GET: InfoBolnices
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

        // GET: InfoBolnices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoBolnice = await _context.infoB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (infoBolnice == null)
            {
                return NotFound();
            }

            return View(infoBolnice);
        }

        // GET: InfoBolnices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoBolnices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,opis")] InfoBolnice infoBolnice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoBolnice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoBolnice);
        }

        // GET: InfoBolnices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoBolnice = await _context.infoB.FindAsync(id);
            if (infoBolnice == null)
            {
                return NotFound();
            }
            return View(infoBolnice);
        }

        // POST: InfoBolnices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,opis")] InfoBolnice infoBolnice)
        {
            if (id != infoBolnice.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoBolnice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoBolniceExists(infoBolnice.ID))
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
            return View(infoBolnice);
        }

        // GET: InfoBolnices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoBolnice = await _context.infoB
                .FirstOrDefaultAsync(m => m.ID == id);
            if (infoBolnice == null)
            {
                return NotFound();
            }

            return View(infoBolnice);
        }

        // POST: InfoBolnices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoBolnice = await _context.infoB.FindAsync(id);
            _context.infoB.Remove(infoBolnice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoBolniceExists(int id)
        {
            return _context.infoB.Any(e => e.ID == id);
        }
    }
}
