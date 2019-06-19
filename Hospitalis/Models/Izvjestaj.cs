using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalisOOAD.Models
{
    public class Izvjestaj : Dokumentacija
    {
        [Required]
        [DisplayName("Zaključak o pregledu")]
        public String rezultatPregleda { get; set; }
    }
}
