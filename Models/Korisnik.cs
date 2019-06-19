using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalisOOAD.Models
{
    public abstract class Korisnik
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Ime")]
        public String ime { get; set; }

        [Required]
        [DisplayName("Prezime")]
        public String prezime { get; set; }
        [NotMapped]
        public string fullname { get { return this.ime + " " + this.prezime; } }

        [Required]
        [EmailAddress]
        
        [DisplayName("E-mail")]
        
         public String email { get; set; }

        [Required]
        [DisplayName("Kontakt telefon")]
        public String kontaktTelefon { get; set; }

        [Required]
        [DisplayName("Korisničko ime")]
        public String username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [DisplayName("Šifra")]
        public String passwordHash { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [DisplayName("Potvrda passworda")]
        [Compare("passwordHash", ErrorMessage = "Unesena polja nisu jednaka!")]
        public String confirmPassword { get; set; }

        [Required]
        [DisplayName("Spol")]
        public String spol { get; set; }
    }
}
