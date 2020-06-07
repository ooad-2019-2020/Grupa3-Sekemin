using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class ZahtjevSobaZaZabavu:Zahtjev
    {
        
        [Display(Name = "Datum slanja")]
        public DateTime DatumSlanja { get; set; }
        [Required]
        [Display(Name = "Trajanje termina")]
        public double Trajanje { get; set; }


    }
}
