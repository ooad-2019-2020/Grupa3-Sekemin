using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekemin.Data.Migrations
{
    public partial class TrecaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpraviteljBibliotekomId",
                table: "Knjige",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvidencijaRadnikaId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Evidencija radnika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencija radnika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(nullable: false),
                    ZahtjevId = table.Column<int>(nullable: false),
                    UpraviteljZaduzivanjaSobaId = table.Column<string>(nullable: true),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    Kraj = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaSmjestaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervacijaSmjestaja_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijaSmjestaja_AspNetUsers_UpraviteljZaduzivanjaSobaId",
                        column: x => x.UpraviteljZaduzivanjaSobaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervacijaSmjestaja_Zahtjevi_ZahtjevId",
                        column: x => x.ZahtjevId,
                        principalTable: "Zahtjevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaSobeZaZabavu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(nullable: false),
                    ZahtjevId = table.Column<int>(nullable: false),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    UpraviteljSobomZaZabavuId = table.Column<string>(nullable: true),
                    Trajanje = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaSobeZaZabavu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervacijaSobeZaZabavu_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijaSobeZaZabavu_AspNetUsers_UpraviteljSobomZaZabavuId",
                        column: x => x.UpraviteljSobomZaZabavuId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervacijaSobeZaZabavu_Zahtjevi_ZahtjevId",
                        column: x => x.ZahtjevId,
                        principalTable: "Zahtjevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    EvidencijaRadnikaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radnici_Evidencija radnika_EvidencijaRadnikaId",
                        column: x => x.EvidencijaRadnikaId,
                        principalTable: "Evidencija radnika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    MenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jela_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sastojci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivSastojka = table.Column<string>(nullable: false),
                    JeloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastojci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sastojci_Jela_JeloId",
                        column: x => x.JeloId,
                        principalTable: "Jela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_UpraviteljBibliotekomId",
                table: "Knjige",
                column: "UpraviteljBibliotekomId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EvidencijaRadnikaId",
                table: "AspNetUsers",
                column: "EvidencijaRadnikaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MenuId",
                table: "AspNetUsers",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_MenuId",
                table: "Jela",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_EvidencijaRadnikaId",
                table: "Radnici",
                column: "EvidencijaRadnikaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaSmjestaja_StudentId",
                table: "RezervacijaSmjestaja",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaSmjestaja_UpraviteljZaduzivanjaSobaId",
                table: "RezervacijaSmjestaja",
                column: "UpraviteljZaduzivanjaSobaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaSmjestaja_ZahtjevId",
                table: "RezervacijaSmjestaja",
                column: "ZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaSobeZaZabavu_StudentId",
                table: "RezervacijaSobeZaZabavu",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaSobeZaZabavu_UpraviteljSobomZaZabavuId",
                table: "RezervacijaSobeZaZabavu",
                column: "UpraviteljSobomZaZabavuId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaSobeZaZabavu_ZahtjevId",
                table: "RezervacijaSobeZaZabavu",
                column: "ZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_Sastojci_JeloId",
                table: "Sastojci",
                column: "JeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Evidencija radnika_EvidencijaRadnikaId",
                table: "AspNetUsers",
                column: "EvidencijaRadnikaId",
                principalTable: "Evidencija radnika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Menu_MenuId",
                table: "AspNetUsers",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_AspNetUsers_UpraviteljBibliotekomId",
                table: "Knjige",
                column: "UpraviteljBibliotekomId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Evidencija radnika_EvidencijaRadnikaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Menu_MenuId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_AspNetUsers_UpraviteljBibliotekomId",
                table: "Knjige");

            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "RezervacijaSmjestaja");

            migrationBuilder.DropTable(
                name: "RezervacijaSobeZaZabavu");

            migrationBuilder.DropTable(
                name: "Sastojci");

            migrationBuilder.DropTable(
                name: "Evidencija radnika");

            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Knjige_UpraviteljBibliotekomId",
                table: "Knjige");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EvidencijaRadnikaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MenuId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpraviteljBibliotekomId",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "EvidencijaRadnikaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "AspNetUsers");
        }
    }
}
