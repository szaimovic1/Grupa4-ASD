using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
        public class Doktor : Korisnik
        {
            [DefaultValue("kod")]
            [DisplayName("Verifikacijski kod")]
            public String verKod { get; set; }
            [Required]
            public String Odjel { get; set; }

        }

}
