using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalisOOAD.Models
{
    public class Pregled
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Termin pregleda")]
        public DateTime termin { get; set; }
        [Required]
        [DisplayName("Stanje")]
        public String zauzet { get; set; }
        [Required]
        [DisplayName("Doktor")]
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        [DefaultValue("")]
        [DisplayName("Ime doktora")]
        public String ime  { get; set; }
        [DefaultValue("")]
        [DisplayName("Prezime")]
        public String prezime  { get; set; }
    }
}