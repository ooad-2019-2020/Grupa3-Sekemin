using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class EvidencijaRadnika
    {
        public EvidencijaRadnika()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            Radnici = new HashSet<Radnici>();
        }

        public int Id { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Radnici> Radnici { get; set; }
    }
}
