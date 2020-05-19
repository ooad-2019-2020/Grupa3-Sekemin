using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public virtual ICollection<Jelo> Jela { get; set; }
    }
}
