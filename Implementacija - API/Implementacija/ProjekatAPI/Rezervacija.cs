using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class Rezervacija
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int ZahtjevId { get; set; }
        public DateTime Pocetak { get; set; }
        public string UpraviteljSobomZaZabavuId { get; set; }
        public double? Trajanje { get; set; }
        public string Discriminator { get; set; }
        public DateTime? Kraj { get; set; }
        public string UpraviteljZaduzivanjaSobaId { get; set; }

        public virtual AspNetUsers Student { get; set; }
        public virtual AspNetUsers UpraviteljSobomZaZabavu { get; set; }
        public virtual AspNetUsers UpraviteljZaduzivanjaSoba { get; set; }
        public virtual Zahtjevi Zahtjev { get; set; }
    }
}
