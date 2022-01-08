using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_WPF.Migrations
{
    public partial class LinkBiletZbor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlecareID",
                table: "Zbor",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlecareID",
                table: "Zbor");
        }
    }
}
