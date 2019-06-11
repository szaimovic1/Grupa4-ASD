using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Doktor //: Korisnik
    {
        public int DoktorId { get; set; }
        public int OdjelId { get; set; }
        public String userId { get; set; }
        public int KorisnikId { get; set; }
        public virtual Odjel Odjel { get; set; }
    }
}
