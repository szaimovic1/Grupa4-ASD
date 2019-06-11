using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Obavjestenje
    {
        public int ObavjestenjeId { get; set; }
        public String tekst { get; set; } 
        public DateTime vrijemeObjave { get; set; }
    }
}
