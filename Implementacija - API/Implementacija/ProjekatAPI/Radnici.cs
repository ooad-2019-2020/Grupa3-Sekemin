using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class Radnici
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int? EvidencijaRadnikaId { get; set; }

        public virtual EvidencijaRadnika EvidencijaRadnika { get; set; }
    }
}
