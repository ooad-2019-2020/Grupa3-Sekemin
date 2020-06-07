using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjekatAPI
{
    public partial class SekeminContext : DbContext
    {
        public SekeminContext()
        {
        }

        public SekeminContext(DbContextOptions<SekeminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<EvidencijaRadnika> EvidencijaRadnika { get; set; }
        public virtual DbSet<Jela> Jela { get; set; }
        public virtual DbSet<Knjige> Knjige { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Radnici> Radnici { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Sastojci> Sastojci { get; set; }
        public virtual DbSet<Sobe> Sobe { get; set; }
        public virtual DbSet<Zahtjevi> Zahtjevi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Sekemin;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.EvidencijaRadnikaId);

                entity.HasIndex(e => e.MenuId);

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.DatumRodjenja).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Grad)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.EvidencijaRadnika)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.EvidencijaRadnikaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<EvidencijaRadnika>(entity =>
            {
                entity.ToTable("Evidencija radnika");
            });

            modelBuilder.Entity<Jela>(entity =>
            {
                entity.HasIndex(e => e.MenuId);

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Jela)
                    .HasForeignKey(d => d.MenuId);
            });

            modelBuilder.Entity<Knjige>(entity =>
            {
                entity.HasIndex(e => e.StudentId);

                entity.HasIndex(e => e.UpraviteljBibliotekomId);

                entity.Property(e => e.ImePisca).IsRequired();

                entity.Property(e => e.NazivDjela).IsRequired();

                entity.Property(e => e.Zanr).IsRequired();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.KnjigeStudent)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.UpraviteljBibliotekom)
                    .WithMany(p => p.KnjigeUpraviteljBibliotekom)
                    .HasForeignKey(d => d.UpraviteljBibliotekomId);
            });

            modelBuilder.Entity<Radnici>(entity =>
            {
                entity.HasIndex(e => e.EvidencijaRadnikaId);

                entity.Property(e => e.Ime).IsRequired();

                entity.Property(e => e.Prezime).IsRequired();

                entity.HasOne(d => d.EvidencijaRadnika)
                    .WithMany(p => p.Radnici)
                    .HasForeignKey(d => d.EvidencijaRadnikaId);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasIndex(e => e.StudentId);

                entity.HasIndex(e => e.UpraviteljSobomZaZabavuId);

                entity.HasIndex(e => e.UpraviteljZaduzivanjaSobaId);

                entity.HasIndex(e => e.ZahtjevId);

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.StudentId).IsRequired();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.RezervacijaStudent)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.UpraviteljSobomZaZabavu)
                    .WithMany(p => p.RezervacijaUpraviteljSobomZaZabavu)
                    .HasForeignKey(d => d.UpraviteljSobomZaZabavuId);

                entity.HasOne(d => d.UpraviteljZaduzivanjaSoba)
                    .WithMany(p => p.RezervacijaUpraviteljZaduzivanjaSoba)
                    .HasForeignKey(d => d.UpraviteljZaduzivanjaSobaId);

                entity.HasOne(d => d.Zahtjev)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.ZahtjevId);
            });

            modelBuilder.Entity<Sastojci>(entity =>
            {
                entity.Property(e => e.NazivSastojka).IsRequired();
            });

            modelBuilder.Entity<Sobe>(entity =>
            {
                entity.HasIndex(e => e.StudentiDrugiId);

                entity.HasIndex(e => e.StudentiPrviId);

                entity.HasOne(d => d.StudentiDrugi)
                    .WithMany(p => p.SobeStudentiDrugi)
                    .HasForeignKey(d => d.StudentiDrugiId);

                entity.HasOne(d => d.StudentiPrvi)
                    .WithMany(p => p.SobeStudentiPrvi)
                    .HasForeignKey(d => d.StudentiPrviId);
            });

            modelBuilder.Entity<Zahtjevi>(entity =>
            {
                entity.HasIndex(e => e.CimerId);

                entity.HasIndex(e => e.KnjigaId);

                entity.HasIndex(e => e.SobaId);

                entity.HasIndex(e => e.StudentId);

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.ZahtjevZaRazduzivanjeDatumSlanja).HasColumnName("ZahtjevZaRazduzivanje_DatumSlanja");

                entity.HasOne(d => d.Cimer)
                    .WithMany(p => p.ZahtjeviCimer)
                    .HasForeignKey(d => d.CimerId);

                entity.HasOne(d => d.Knjiga)
                    .WithMany(p => p.Zahtjevi)
                    .HasForeignKey(d => d.KnjigaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Zahtjevi)
                    .HasForeignKey(d => d.SobaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ZahtjeviStudent)
                    .HasForeignKey(d => d.StudentId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
