﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sekemin.Data;

namespace Sekemin.Data.Migrations
{
    [DbContext(typeof(BazaContext))]
    [Migration("20200606034235_PopravkaSobe")]
    partial class PopravkaSobe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Sekemin.Models.EvidencijaRadnika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Evidencija radnika");
                });

            modelBuilder.Entity("Sekemin.Models.Jelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Jela");
                });

            modelBuilder.Entity("Sekemin.Models.Knjiga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojIzdanja")
                        .HasColumnType("int");

                    b.Property<string>("ImePisca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivDjela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpraviteljBibliotekomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Zanr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("UpraviteljBibliotekomId");

                    b.ToTable("Knjige");
                });

            modelBuilder.Entity("Sekemin.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Sekemin.Models.Osoba", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Spol")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Uloga")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Osoba");
                });

            modelBuilder.Entity("Sekemin.Models.Radnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EvidencijaRadnikaId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EvidencijaRadnikaId");

                    b.ToTable("Radnici");
                });

            modelBuilder.Entity("Sekemin.Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Pocetak")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ZahtjevId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("ZahtjevId");

                    b.ToTable("Rezervacija");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Rezervacija");
                });

            modelBuilder.Entity("Sekemin.Models.Sastojak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("JeloId")
                        .HasColumnType("int");

                    b.Property<string>("NazivSastojka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JeloId");

                    b.ToTable("Sastojci");
                });

            modelBuilder.Entity("Sekemin.Models.Soba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RedniBroj")
                        .HasColumnType("int");

                    b.Property<int>("Sprat")
                        .HasColumnType("int");

                    b.Property<string>("StudentDrugiId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentPrviId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentiDrugiId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentiPrviId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StudentiDrugiId");

                    b.HasIndex("StudentiPrviId");

                    b.ToTable("Sobe");
                });

            modelBuilder.Entity("Sekemin.Models.Zahtjev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId1");

                    b.ToTable("Zahtjevi");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Zahtjev");
                });

            modelBuilder.Entity("Sekemin.Models.Student", b =>
                {
                    b.HasBaseType("Sekemin.Models.Osoba");

                    b.Property<int>("BrojBonova")
                        .HasColumnType("int");

                    b.Property<string>("Fakultet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GodinaStudija")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Sekemin.Models.UpraviteljBibliotekom", b =>
                {
                    b.HasBaseType("Sekemin.Models.Osoba");

                    b.HasDiscriminator().HasValue("UpraviteljBibliotekom");
                });

            modelBuilder.Entity("Sekemin.Models.UpraviteljHranom", b =>
                {
                    b.HasBaseType("Sekemin.Models.Osoba");

                    b.Property<int>("EvidencijaRadnikaId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.HasIndex("EvidencijaRadnikaId");

                    b.HasIndex("MenuId");

                    b.HasDiscriminator().HasValue("UpraviteljHranom");
                });

            modelBuilder.Entity("Sekemin.Models.UpraviteljSobomZaZabavu", b =>
                {
                    b.HasBaseType("Sekemin.Models.Osoba");

                    b.HasDiscriminator().HasValue("UpraviteljSobomZaZabavu");
                });

            modelBuilder.Entity("Sekemin.Models.UpraviteljZaduzivanjaSoba", b =>
                {
                    b.HasBaseType("Sekemin.Models.Osoba");

                    b.HasDiscriminator().HasValue("UpraviteljZaduzivanjaSoba");
                });

            modelBuilder.Entity("Sekemin.Models.RezervacijaSmjestaja", b =>
                {
                    b.HasBaseType("Sekemin.Models.Rezervacija");

                    b.Property<DateTime>("Kraj")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpraviteljZaduzivanjaSobaId")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UpraviteljZaduzivanjaSobaId");

                    b.HasDiscriminator().HasValue("RezervacijaSmjestaja");
                });

            modelBuilder.Entity("Sekemin.Models.RezervacijaSobeZaZabavu", b =>
                {
                    b.HasBaseType("Sekemin.Models.Rezervacija");

                    b.Property<double>("Trajanje")
                        .HasColumnType("float");

                    b.Property<string>("UpraviteljSobomZaZabavuId")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UpraviteljSobomZaZabavuId");

                    b.HasDiscriminator().HasValue("RezervacijaSobeZaZabavu");
                });

            modelBuilder.Entity("Sekemin.Models.ZahtjevSobaZaZabavu", b =>
                {
                    b.HasBaseType("Sekemin.Models.Zahtjev");

                    b.Property<DateTime>("DatumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<double>("Trajanje")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("ZahtjevSobaZaZabavu");
                });

            modelBuilder.Entity("Sekemin.Models.ZahtjevZaPodizanjeKnjige", b =>
                {
                    b.HasBaseType("Sekemin.Models.Zahtjev");

                    b.Property<int>("KnjigaId")
                        .HasColumnType("int");

                    b.HasIndex("KnjigaId");

                    b.HasDiscriminator().HasValue("ZahtjevZaPodizanjeKnjige");
                });

            modelBuilder.Entity("Sekemin.Models.ZahtjevZaRazduzivanje", b =>
                {
                    b.HasBaseType("Sekemin.Models.Zahtjev");

                    b.Property<DateTime>("DatumSlanja")
                        .HasColumnName("ZahtjevZaRazduzivanje_DatumSlanja")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("ZahtjevZaRazduzivanje");
                });

            modelBuilder.Entity("Sekemin.Models.ZahtjevZaSmjestaj", b =>
                {
                    b.HasBaseType("Sekemin.Models.Zahtjev");

                    b.Property<string>("CimerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SobaId")
                        .HasColumnType("int");

                    b.HasIndex("SobaId");

                    b.HasIndex("StudentId");

                    b.HasDiscriminator().HasValue("ZahtjevZaSmjestaj");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sekemin.Models.Osoba", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sekemin.Models.Osoba", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sekemin.Models.Osoba", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sekemin.Models.Osoba", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sekemin.Models.Jelo", b =>
                {
                    b.HasOne("Sekemin.Models.Menu", null)
                        .WithMany("Jela")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("Sekemin.Models.Knjiga", b =>
                {
                    b.HasOne("Sekemin.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Sekemin.Models.UpraviteljBibliotekom", null)
                        .WithMany("Knjige")
                        .HasForeignKey("UpraviteljBibliotekomId");
                });

            modelBuilder.Entity("Sekemin.Models.Radnik", b =>
                {
                    b.HasOne("Sekemin.Models.EvidencijaRadnika", null)
                        .WithMany("Radnici")
                        .HasForeignKey("EvidencijaRadnikaId");
                });

            modelBuilder.Entity("Sekemin.Models.Rezervacija", b =>
                {
                    b.HasOne("Sekemin.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sekemin.Models.Zahtjev", "Zahtjev")
                        .WithMany()
                        .HasForeignKey("ZahtjevId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sekemin.Models.Sastojak", b =>
                {
                    b.HasOne("Sekemin.Models.Jelo", null)
                        .WithMany("Sastojci")
                        .HasForeignKey("JeloId");
                });

            modelBuilder.Entity("Sekemin.Models.Soba", b =>
                {
                    b.HasOne("Sekemin.Models.Student", "StudentDrugi")
                        .WithMany()
                        .HasForeignKey("StudentiDrugiId");

                    b.HasOne("Sekemin.Models.Student", "StudentPrvi")
                        .WithMany()
                        .HasForeignKey("StudentiPrviId");
                });

            modelBuilder.Entity("Sekemin.Models.Zahtjev", b =>
                {
                    b.HasOne("Sekemin.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId1");
                });

            modelBuilder.Entity("Sekemin.Models.UpraviteljHranom", b =>
                {
                    b.HasOne("Sekemin.Models.EvidencijaRadnika", "EvidencijaRadnika")
                        .WithMany()
                        .HasForeignKey("EvidencijaRadnikaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sekemin.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sekemin.Models.RezervacijaSmjestaja", b =>
                {
                    b.HasOne("Sekemin.Models.UpraviteljZaduzivanjaSoba", "UpraviteljZaduzivanjaSoba")
                        .WithMany("RezervacijaSmjestaja")
                        .HasForeignKey("UpraviteljZaduzivanjaSobaId");
                });

            modelBuilder.Entity("Sekemin.Models.RezervacijaSobeZaZabavu", b =>
                {
                    b.HasOne("Sekemin.Models.UpraviteljSobomZaZabavu", "UpraviteljSobomZaZabavu")
                        .WithMany("Rezervacije")
                        .HasForeignKey("UpraviteljSobomZaZabavuId");
                });

            modelBuilder.Entity("Sekemin.Models.ZahtjevZaPodizanjeKnjige", b =>
                {
                    b.HasOne("Sekemin.Models.Knjiga", "Knjiga")
                        .WithMany()
                        .HasForeignKey("KnjigaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sekemin.Models.ZahtjevZaSmjestaj", b =>
                {
                    b.HasOne("Sekemin.Models.Soba", "Soba")
                        .WithMany()
                        .HasForeignKey("SobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sekemin.Models.Student", "Cimer")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
