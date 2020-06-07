using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class Zahtjevi
    {
        public Zahtjevi()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Discriminator { get; set; }
        public DateTime? DatumSlanja { get; set; }
        public double? Trajanje { get; set; }
        public int? KnjigaId { get; set; }
        public DateTime? ZahtjevZaRazduzivanjeDatumSlanja { get; set; }
        public int? SobaId { get; set; }
        public string CimerId { get; set; }

        public virtual AspNetUsers Cimer { get; set; }
        public virtual Knjige Knjiga { get; set; }
        public virtual Sobe Soba { get; set; }
        public virtual AspNetUsers Student { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
