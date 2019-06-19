using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalisOOAD.Models;
using System.Net.Mail;
using System.Net;

namespace HospitalisOOAD.Controllers
{
    public class DoktorsController : Controller
    {
        private readonly HospitalisContext _context;
        public static Korisnik currentlyLogged = null;
        private static int code;
        private static Doktor doktorKojiSeDodaje;

        public DoktorsController(HospitalisContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doktor doktor)
        {
            List<Korisnik> provjeraUser = _context.korisnici.Where(p => p.username == doktor.username).ToList();
            if (provjeraUser.Count() != 0)
            {
                ViewBag.Message = "Korisničko ime je već u upotrebi!";
                return View();

            }
            List<Korisnik> provjeraMail = _context.korisnici.Where(p => p.email == doktor.email).ToList();
            if (provjeraMail.Count() != 0)
            {
                ViewBag.Message = "Email je već u upotrebi!";
                return View();
            }

            if(doktor.email != "sarazaimovic@gmail.com" || doktor.email != "ajsahaj@gmail.com" || doktor.email != "almirzulum@gmail.com"
                || doktor.email != "dbasalic1@etf.unsa.ba" || doktor.email != "khodzic2@etf.unsa.ba")
            {
                ViewBag.Message = "Niste evidentirani kao doktor!";
                return View();
            }
            if (ModelState.IsValid) 
            {
                doktorKojiSeDodaje = doktor;
                Random rnd = new Random();
                code = rnd.Next(10000, 99999);
                return RedirectToAction("SendEmail", "Doktors");
            }
            return View();
        }
        public IActionResult SendEmail()
        {
            var fromAddress = new MailAddress("hospitalis.0043@gmail.com", "Hospitalis");
            var toAddress = new MailAddress(doktorKojiSeDodaje.email, null);
            const string fromPassword = "pacijentnaprvommjestu";
            const string subject = "Kod za pristup računu";
            string body = "Za aktivaciju računa unesite sljedeći kod: " + code;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("hospitalis.0043@gmail.com", fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string aktivacijskiKod)
        {
            if(aktivacijskiKod != null)
            {
                doktorKojiSeDodaje.verKod = aktivacijskiKod;
                if (code == Int32.Parse(aktivacijskiKod))
                {
                    _context.doktori.Add(doktorKojiSeDodaje);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "DoktorovMeni");
                }
            }         
            return View();
        }


        // GET: Doktors
        public async Task<IActionResult> Index()
        {
            return View(await _context.doktori.ToListAsync());
        }

        // GET: Doktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktori
                .Include(d => d.Odjel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktors/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Doktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktori.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("verKod,OdjelId,ID,ime,prezime,email,kontaktTelefon,username,passwordHash,spol")] Doktor doktor)
        {
            if (id != doktor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.ID))
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
            return View(doktor);
        }

        // GET: Doktors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktori
                .Include(d => d.Odjel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doktor = await _context.doktori.FindAsync(id);
            _context.doktori.Remove(doktor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return _context.doktori.Any(e => e.ID == id);
        }
    }
}


