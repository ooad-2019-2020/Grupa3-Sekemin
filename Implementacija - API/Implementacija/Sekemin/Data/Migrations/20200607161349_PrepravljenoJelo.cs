using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekemin.Data.Migrations
{
    public partial class PrepravljenoJelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sastojci_Jela_JeloId",
                table: "Sastojci");

            migrationBuilder.DropIndex(
                name: "IX_Sastojci_JeloId",
                table: "Sastojci");

            migrationBuilder.DropColumn(
                name: "JeloId",
                table: "Sastojci");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Jela",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Jela");

            migrationBuilder.AddColumn<int>(
                name: "JeloId",
                table: "Sastojci",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sastojci_JeloId",
                table: "Sastojci",
                column: "JeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sastojci_Jela_JeloId",
                table: "Sastojci",
                column: "JeloId",
                principalTable: "Jela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
