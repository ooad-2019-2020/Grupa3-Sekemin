using Microsoft.EntityFrameworkCore.Migrations;

namespace Sekemin.Data.Migrations
{
    public partial class DodavanjeUloga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Uloga",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uloga",
                table: "AspNetUsers");
        }
    }
}
