using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class UpraviteljZaduzivanjaSoba:Osoba
    {

        public virtual ICollection<RezervacijaSmjestaja> RezervacijaSmjestaja { get; set; }
    }
}
