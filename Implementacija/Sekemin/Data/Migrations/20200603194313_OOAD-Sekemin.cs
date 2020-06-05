using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekemin.Data.Migrations
{
    public partial class OOADSekemin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaSobeZaZabavu_AspNetUsers_StudentId",
                table: "RezervacijaSobeZaZabavu");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaSobeZaZabavu_AspNetUsers_UpraviteljSobomZaZabavuId",
                table: "RezervacijaSobeZaZabavu");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaSobeZaZabavu_Zahtjevi_ZahtjevId",
                table: "RezervacijaSobeZaZabavu");

            migrationBuilder.DropTable(
                name: "RezervacijaSmjestaja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RezervacijaSobeZaZabavu",
                table: "RezervacijaSobeZaZabavu");

            migrationBuilder.RenameTable(
                name: "RezervacijaSobeZaZabavu",
                newName: "Rezervacija");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaSobeZaZabavu_ZahtjevId",
                table: "Rezervacija",
                newName: "IX_Rezervacija_ZahtjevId");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaSobeZaZabavu_UpraviteljSobomZaZabavuId",
                table: "Rezervacija",
                newName: "IX_Rezervacija_UpraviteljSobomZaZabavuId");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaSobeZaZabavu_StudentId",
                table: "Rezervacija",
                newName: "IX_Rezervacija_StudentId");

            migrationBuilder.AlterColumn<double>(
                name: "Trajanje",
                table: "Rezervacija",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Rezervacija",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Kraj",
                table: "Rezervacija",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpraviteljZaduzivanjaSobaId",
                table: "Rezervacija",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_UpraviteljZaduzivanjaSobaId",
                table: "Rezervacija",
                column: "UpraviteljZaduzivanjaSobaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_AspNetUsers_StudentId",
                table: "Rezervacija",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Zahtjevi_ZahtjevId",
                table: "Rezervacija",
                column: "ZahtjevId",
                principalTable: "Zahtjevi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_AspNetUsers_UpraviteljZaduzivanjaSobaId",
                table: "Rezervacija",
                column: "UpraviteljZaduzivanjaSobaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_AspNetUsers_UpraviteljSobomZaZabavuId",
                table: "Rezervacija",
                column: "UpraviteljSobomZaZabavuId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_AspNetUsers_StudentId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Zahtjevi_ZahtjevId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_AspNetUsers_UpraviteljZaduzivanjaSobaId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_AspNetUsers_UpraviteljSobomZaZabavuId",
                table: "Rezervacija");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_UpraviteljZaduzivanjaSobaId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "Kraj",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "UpraviteljZaduzivanjaSobaId",
                table: "Rezervacija");

            migrationBuilder.RenameTable(
                name: "Rezervacija",
                newName: "RezervacijaSobeZaZabavu");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_UpraviteljSobomZaZabavuId",
                table: "RezervacijaSobeZaZabavu",
                newName: "IX_RezervacijaSobeZaZabavu_UpraviteljSobomZaZabavuId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_ZahtjevId",
                table: "RezervacijaSobeZaZabavu",
                newName: "IX_RezervacijaSobeZaZabavu_ZahtjevId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_StudentId",
                table: "RezervacijaSobeZaZabavu",
                newName: "IX_RezervacijaSobeZaZabavu_StudentId");

            migrationBuilder.AlterColumn<double>(
                name: "Trajanje",
                table: "RezervacijaSobeZaZabavu",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RezervacijaSobeZaZabavu",
                table: "RezervacijaSobeZaZabavu",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RezervacijaSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpraviteljZaduzivanjaSobaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ZahtjevId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaSobeZaZabavu_AspNetUsers_StudentId",
                table: "RezervacijaSobeZaZabavu",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaSobeZaZabavu_AspNetUsers_UpraviteljSobomZaZabavuId",
                table: "RezervacijaSobeZaZabavu",
                column: "UpraviteljSobomZaZabavuId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaSobeZaZabavu_Zahtjevi_ZahtjevId",
                table: "RezervacijaSobeZaZabavu",
                column: "ZahtjevId",
                principalTable: "Zahtjevi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
