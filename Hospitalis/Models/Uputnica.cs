using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Uputnica //: Dokumentacija
    {
        public int UputnicaId { get; set; }
        public String svrha { get; set; }
        public String odrediste { get; set; }
        public int DokumentacijaId { get; set; }

    }
}
