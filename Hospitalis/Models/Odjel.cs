using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Odjel
    {
        public int OdjelId { get; set; }
        public String naziv { get; set; }
        public int InfoBolniceId { get; set; }
        public virtual InfoBolnice InfoBolnice { get; set; }

    }
}
