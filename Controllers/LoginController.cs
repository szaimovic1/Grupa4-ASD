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
    public class LoginController : Controller
    {

        private readonly HospitalisContext _context;
        public LoginController(HospitalisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(String user, String sifra)
        {
            List<Pacijent> trazimoPac = _context.pacijenti.Where(p => p.username == user).ToList();
            if(trazimoPac.Count() != 0)
            {
                if(trazimoPac[0].passwordHash != sifra)
                {
                    ViewBag.Message = "Pogrešna šifra!";
                    return View();
                }
                return Redirect("~/IzborniMeni");
            }

            List<Doktor> trazimoDr = _context.doktori.Where(p => p.username == user).ToList();
            if (trazimoDr.Count() != 0)
            {
                if (trazimoDr[0].passwordHash != sifra)
                {
                    ViewBag.Message = "Pogrešna šifra!";
                    return View();
                }
                return Redirect("~/DoktorovMeni");
            }
            ViewBag.Message = "Pogrešno korisničko ime!";

            return View();
        }
    }
}