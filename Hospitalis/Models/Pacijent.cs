using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Pacijent //: Korisnik
    {
        public int PacijentId { get; set; }
        public String jmbg { get; set; }
        public DateTime datumRodjenja { get; set; }
        public String adresaPrebivalista { get; set; }
        public String gradRodjenja { get; set; }
        public String drzavaRodjenja { get; set; }
        public int KorisnikId { get; set; }
    }
}
