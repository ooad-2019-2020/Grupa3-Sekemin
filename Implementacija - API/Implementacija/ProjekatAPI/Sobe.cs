using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class Sobe
    {
        public Sobe()
        {
            Zahtjevi = new HashSet<Zahtjevi>();
        }

        public int Id { get; set; }
        public int Sprat { get; set; }
        public string StudentPrviId { get; set; }
        public string StudentDrugiId { get; set; }
        public string StudentiPrviId { get; set; }
        public string StudentiDrugiId { get; set; }
        public int RedniBroj { get; set; }

        public virtual AspNetUsers StudentiDrugi { get; set; }
        public virtual AspNetUsers StudentiPrvi { get; set; }
        public virtual ICollection<Zahtjevi> Zahtjevi { get; set; }
    }
}
