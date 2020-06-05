using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sekemin.Models;

namespace Sekemin.Data
{
    public class BazaContext : IdentityDbContext<Osoba>
    {
        public BazaContext(DbContextOptions<BazaContext> options)
            : base(options)
        {
        }

        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Knjiga> Knjiga { get; set; }
        public DbSet<Soba> Soba { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<ZahtjevSobaZaZabavu> ZahtjevSobaZaZabavu { get; set; }
        public DbSet<ZahtjevZaPodizanjeKnjige> ZahtjevZaPodizanjeKnjige { get; set; }
        public DbSet<ZahtjevZaRazduzivanje> ZahtjevZaRazduzivanje { get; set; }
        public DbSet<ZahtjevZaSmjestaj> ZahtjevZaSmjestaj { get; set; }

        public DbSet<EvidencijaRadnika> EvidencijaRadnika { get; set; }
        public DbSet<Jelo> Jelo { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Radnik> Radnik { get; set; }
        public DbSet<Sastojak> Sastojak { get; set; }

        public DbSet<UpraviteljBibliotekom> UpraviteljBibliotekom { get; set; }
        public DbSet<UpraviteljHranom> UpraviteljHranom { get; set; }
        public DbSet<UpraviteljSobomZaZabavu> UpraviteljSobomZaZabavu { get; set; }
        public DbSet<UpraviteljZaduzivanjaSoba> UpraviteljZaduzivanjaSoba { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Knjiga>().ToTable("Knjige");
            builder.Entity<Soba>().ToTable("Sobe");
            builder.Entity<Zahtjev>().ToTable("Zahtjevi");
            builder.Entity<EvidencijaRadnika>().ToTable("Evidencija radnika");
            builder.Entity<Jelo>().ToTable("Jela");
            builder.Entity<Menu>().ToTable("Menu");
            builder.Entity<Radnik>().ToTable("Radnici");
            builder.Entity<Sastojak>().ToTable("Sastojci");


        }

        public DbSet<Sekemin.Models.Rezervacija> Rezervacija { get; set; }


    }
}
