using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class UpraviteljBibliotekom:Osoba
    {

        public virtual ICollection<Knjiga> Knjige { get; set; }
    }
}
