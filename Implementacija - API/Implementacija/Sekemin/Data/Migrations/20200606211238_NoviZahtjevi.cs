using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekemin.Data.Migrations
{
    public partial class NoviZahtjevi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_StudentId",
                table: "Zahtjevi");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_StudentId",
                table: "Zahtjevi",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_StudentId",
                table: "Zahtjevi");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_StudentId",
                table: "Zahtjevi",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
