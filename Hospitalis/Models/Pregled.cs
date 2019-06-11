using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Pregled
    {
        public int PregledId { get; set; }
        public int DoktorId { get; set; }
        public int PacijentId { get; set; }
        public DateTime termin { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; } 
    }
}
