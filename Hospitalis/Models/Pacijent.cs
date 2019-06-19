using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalisOOAD.Models
{
    public class Pacijent : Korisnik
    {

        [Required]
        [DisplayName("JMBG")]
        public String jmbg { get; set; }
        [Required]
        [DisplayName("Datum rođenja")]
        public DateTime datumRodjenja { get; set; }
        [Required]
        [DisplayName("Adresa")]
        public String adresaPrebivalista { get; set; }
        [Required]
        [DisplayName("Grad")]
        public String gradRodjenja { get; set; }
        [Required]
        [DisplayName("Država")]
        public String drzavaRodjenja { get; set; }
    }
}
