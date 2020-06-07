using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class Knjige
    {
        public Knjige()
        {
            Zahtjevi = new HashSet<Zahtjevi>();
        }

        public int Id { get; set; }
        public string NazivDjela { get; set; }
        public string Zanr { get; set; }
        public string ImePisca { get; set; }
        public int BrojIzdanja { get; set; }
        public string StudentId { get; set; }
        public string UpraviteljBibliotekomId { get; set; }

        public virtual AspNetUsers Student { get; set; }
        public virtual AspNetUsers UpraviteljBibliotekom { get; set; }
        public virtual ICollection<Zahtjevi> Zahtjevi { get; set; }
    }
}
