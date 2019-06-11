using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String email { get; set; }
        public String kontaktTelefon { get; set; }
        public String username { get; set; }
        public String passwordHash { get; set; }
        public String spol { get; set; }

    }
}
