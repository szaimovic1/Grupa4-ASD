using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalisOOAD.Models
{
    public class Anketa
    {
        public int ID { get; set; }
        public int doktorID { get; set; }
        [Required]
        [Range(1, 5)]
        public int ocjena1 { get; set; }
        [Required]
        [Range(1, 5)]
        public int ocjena2 { get; set; }
        [Required]
        [Range(1, 5)]
        public int ocjena3 { get; set; }
        [Required]
        [Range(1, 5)]
        public int ocjena4 { get; set; }
        [Required]
        [Range(1, 5)]
        public int ocjena5 { get; set; }

        public double konacnaOcjena { get; set; }
    }
}

