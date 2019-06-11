using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Dokumentacija
    {
        public int DokumentacijaId { get; set; }
        public DateTime datumIzdavanja { get; set; }
        public int DoktorId { get; set; }
        public int PacijentId { get; set; }
        public int PregledId { get; set; }
        public virtual Pregled Pregled { get; set; }
    }
}
