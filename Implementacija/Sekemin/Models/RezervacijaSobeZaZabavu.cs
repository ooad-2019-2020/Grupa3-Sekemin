using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class RezervacijaSobeZaZabavu:Rezervacija
    {
        
        public string UpraviteljSobomZaZabavuId { get; set; }
        
        [Required]
        public double Trajanje { get; set; }


        public virtual UpraviteljSobomZaZabavu UpraviteljSobomZaZabavu { get; set; }

    }
}
