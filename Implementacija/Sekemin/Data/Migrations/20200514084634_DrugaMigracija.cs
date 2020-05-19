using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekemin.Data.Migrations
{
    public partial class DrugaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Knjige",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDjela = table.Column<string>(nullable: false),
                    Zanr = table.Column<string>(nullable: false),
                    ImePisca = table.Column<string>(nullable: false),
                    BrojIzdanja = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knjige_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sprat = table.Column<int>(nullable: false),
                    StudentPrviId = table.Column<string>(nullable: false),
                    StudentDrugiId = table.Column<string>(nullable: true),
                    StudentiPrviId = table.Column<string>(nullable: true),
                    StudentiDrugiId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sobe_AspNetUsers_StudentiDrugiId",
                        column: x => x.StudentiDrugiId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sobe_AspNetUsers_StudentiPrviId",
                        column: x => x.StudentiPrviId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjevi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(nullable: true),
                    StudentId1 = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DatumSlanja = table.Column<DateTime>(nullable: true),
                    Trajanje = table.Column<double>(nullable: true),
                    KnjigaId = table.Column<int>(nullable: true),
                    ZahtjevZaRazduzivanje_DatumSlanja = table.Column<DateTime>(nullable: true),
                    SobaId = table.Column<int>(nullable: true),
                    CimerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_AspNetUsers_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_Sobe_SobaId",
                        column: x => x.SobaId,
                        principalTable: "Sobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtjevi_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_StudentId",
                table: "Knjige",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_StudentiDrugiId",
                table: "Sobe",
                column: "StudentiDrugiId");

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_StudentiPrviId",
                table: "Sobe",
                column: "StudentiPrviId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_StudentId1",
                table: "Zahtjevi",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_KnjigaId",
                table: "Zahtjevi",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_SobaId",
                table: "Zahtjevi",
                column: "SobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_StudentId",
                table: "Zahtjevi",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zahtjevi");

            migrationBuilder.DropTable(
                name: "Knjige");

            migrationBuilder.DropTable(
                name: "Sobe");
        }
    }
}
