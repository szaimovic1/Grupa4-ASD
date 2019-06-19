using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalisOOAD.Models
{
    public class Uputnica : Dokumentacija
    {
        [Required]
        [DisplayName("Svrha uputnice")]
        public String svrha { get; set; }
        [Required]
        [DisplayName("Uputnica za (doktor, bolnica)")]
        public String odrediste { get; set; }

    }
}
