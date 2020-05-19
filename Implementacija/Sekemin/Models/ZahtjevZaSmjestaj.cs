using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class ZahtjevZaSmjestaj : Zahtjev
    {
        public int SobaId { get; set; }
        public string CimerId { get; set; }

        [ForeignKey("SobaId")]
        public virtual Soba Soba {get; set;}
        [ForeignKey("StudentId")]
        public virtual Student Cimer { get; set; }

    }
}
