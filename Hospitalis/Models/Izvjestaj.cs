using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Izvjestaj //: Dokumentacija
    {
        public int IzvjestajId { get; set; }
        public String rezultatPregleda { get; set; }
        public int DokumentacijaId { get; set; }
    }
}
