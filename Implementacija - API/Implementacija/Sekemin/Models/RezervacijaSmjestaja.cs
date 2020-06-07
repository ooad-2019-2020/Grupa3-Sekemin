using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class RezervacijaSmjestaja:Rezervacija
    {
        public string UpraviteljZaduzivanjaSobaId { get; set; }
        
        //public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        [ForeignKey("UpraviteljZaduzivanjaSobaId")]
        public virtual UpraviteljZaduzivanjaSoba UpraviteljZaduzivanjaSoba { get; set; }
    }
}
