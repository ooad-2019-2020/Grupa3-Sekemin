using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class ZahtjevZaPodizanjeKnjige:Zahtjev
    {
        public int KnjigaId { get; set; }


        public virtual Knjiga Knjiga { get; set; }
    }
}
