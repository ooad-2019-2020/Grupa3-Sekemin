using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekemin.Data.Migrations
{
    public partial class ZahtjevZaSmjestaj2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_StudentId1",
                table: "Zahtjevi");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjevi_StudentId1",
                table: "Zahtjevi");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Zahtjevi");

            migrationBuilder.AlterColumn<string>(
                name: "CimerId",
                table: "Zahtjevi",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_CimerId",
                table: "Zahtjevi",
                column: "CimerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_CimerId",
                table: "Zahtjevi",
                column: "CimerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_CimerId",
                table: "Zahtjevi");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjevi_CimerId",
                table: "Zahtjevi");

            migrationBuilder.AlterColumn<string>(
                name: "CimerId",
                table: "Zahtjevi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "Zahtjevi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjevi_StudentId1",
                table: "Zahtjevi",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjevi_AspNetUsers_StudentId1",
                table: "Zahtjevi",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
