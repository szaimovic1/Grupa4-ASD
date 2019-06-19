using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalisOOAD.Models
{
    public class Obavjestenje
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Sadržaj")]
        public String tekst { get; set; }
        [Required]
        [DisplayName("Vrijeme objave")]
        public DateTime vrijemeObjave { get; set; }
    }
}
