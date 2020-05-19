using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class UpraviteljHranom:Osoba
    {
        public int MenuId { get; set; }
        public int EvidencijaRadnikaId { get; set; }


        public virtual Menu Menu { get; set; }
        public virtual EvidencijaRadnika EvidencijaRadnika { get; set; }
    }
}
