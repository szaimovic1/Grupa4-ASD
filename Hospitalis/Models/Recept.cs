using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalisOOAD.Models
{
    public class Recept : Dokumentacija
    {
        [Required]
        [DisplayName("Lijek")]
        public String nazivLijeka { get; set; }

    }
}
    
