using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class EvidencijaRadnika
    {
        public int Id { get; set; }
        public virtual ICollection<Radnik> Radnici { get; set; }

    }
}
