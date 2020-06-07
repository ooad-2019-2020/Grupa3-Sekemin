using System;
using System.Collections.Generic;

namespace ProjekatAPI
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            KnjigeStudent = new HashSet<Knjige>();
            KnjigeUpraviteljBibliotekom = new HashSet<Knjige>();
            RezervacijaStudent = new HashSet<Rezervacija>();
            RezervacijaUpraviteljSobomZaZabavu = new HashSet<Rezervacija>();
            RezervacijaUpraviteljZaduzivanjaSoba = new HashSet<Rezervacija>();
            SobeStudentiDrugi = new HashSet<Sobe>();
            SobeStudentiPrvi = new HashSet<Sobe>();
            ZahtjeviCimer = new HashSet<Zahtjevi>();
            ZahtjeviStudent = new HashSet<Zahtjevi>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Discriminator { get; set; }
        public string Grad { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Spol { get; set; }
        public string Fakultet { get; set; }
        public int? GodinaStudija { get; set; }
        public int? EvidencijaRadnikaId { get; set; }
        public int? MenuId { get; set; }
        public int Uloga { get; set; }
        public int? BrojBonova { get; set; }

        public virtual EvidencijaRadnika EvidencijaRadnika { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Knjige> KnjigeStudent { get; set; }
        public virtual ICollection<Knjige> KnjigeUpraviteljBibliotekom { get; set; }
        public virtual ICollection<Rezervacija> RezervacijaStudent { get; set; }
        public virtual ICollection<Rezervacija> RezervacijaUpraviteljSobomZaZabavu { get; set; }
        public virtual ICollection<Rezervacija> RezervacijaUpraviteljZaduzivanjaSoba { get; set; }
        public virtual ICollection<Sobe> SobeStudentiDrugi { get; set; }
        public virtual ICollection<Sobe> SobeStudentiPrvi { get; set; }
        public virtual ICollection<Zahtjevi> ZahtjeviCimer { get; set; }
        public virtual ICollection<Zahtjevi> ZahtjeviStudent { get; set; }
    }
}
