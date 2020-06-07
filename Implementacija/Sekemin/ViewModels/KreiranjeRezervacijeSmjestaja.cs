using Sekemin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.ViewModels
{
    public class KreiranjeRezervacijeSmjestaja
    {
        public RezervacijaSmjestaja rezervacijaSmjestaja { get; set; }
        public ZahtjevZaSmjestaj zahtjev { get; set; }
    }
}
