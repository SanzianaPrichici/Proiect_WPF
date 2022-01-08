using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_WPF.Migrations
{
    public partial class Addaeroport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "Aeroport_plecareID",
                table: "Zbor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aeroport",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroport", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zbor_Aeroport_plecareID",
                table: "Zbor",
                column: "Aeroport_plecareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_Aeroport_Aeroport_plecareID",
                table: "Zbor",
                column: "Aeroport_plecareID",
                principalTable: "Aeroport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_Aeroport_Aeroport_plecareID",
                table: "Zbor");

            migrationBuilder.DropTable(
                name: "Aeroport");

            migrationBuilder.DropIndex(
                name: "IX_Zbor_Aeroport_plecareID",
                table: "Zbor");

            migrationBuilder.DropColumn(
                name: "Aeroport_plecareID",
                table: "Zbor");

            migrationBuilder.AddColumn<int>(
                name: "ZborID",
                table: "Bilet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
