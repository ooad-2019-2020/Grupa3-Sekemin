using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class Jela
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? MenuId { get; set; }
        public string Opis { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
