using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalisOOAD.Models
{
    public abstract class Dokumentacija
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Datum izdavanja")]
        public DateTime datumIzdavanja { get; set; }
        [Required]
        [DisplayName("Pacijent")]
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        [Required]
        [DisplayName("Odjel")]
        public String Odjel { get; set; }

    }
}

