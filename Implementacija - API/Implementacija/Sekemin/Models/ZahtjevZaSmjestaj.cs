using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class ZahtjevZaSmjestaj : Zahtjev
    {
        public int SobaId { get; set; }
        [Display(Name ="Odaberi cimera")]
        public string CimerId { get; set; }
        [Display(Name ="Odaberi sobu")]
        [ForeignKey("SobaId")]
        public virtual Soba Soba {get; set;}
        [ForeignKey("CimerId")]
        public virtual Student Cimer { get; set; }

    }
}
