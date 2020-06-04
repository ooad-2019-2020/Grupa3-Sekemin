using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Zahtjev
    {
        public int Id { get; set; }
        public string StudentId { get; set; }


        //mislim da se ne smije staviti objekaat tipa Osoba, jer bi kreirao tabelu
        public virtual Student Student { get; set; }

    }
}
