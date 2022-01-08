using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_WPF.Migrations
{
    public partial class ChangeAeroport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_Aeroport_Aeroport_plecareID",
                table: "Zbor");

            migrationBuilder.RenameColumn(
                name: "Aeroport_plecareID",
                table: "Zbor",
                newName: "AeroportID");

            migrationBuilder.RenameIndex(
                name: "IX_Zbor_Aeroport_plecareID",
                table: "Zbor",
                newName: "IX_Zbor_AeroportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_Aeroport_AeroportID",
                table: "Zbor",
                column: "AeroportID",
                principalTable: "Aeroport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zbor_Aeroport_AeroportID",
                table: "Zbor");

            migrationBuilder.RenameColumn(
                name: "AeroportID",
                table: "Zbor",
                newName: "Aeroport_plecareID");

            migrationBuilder.RenameIndex(
                name: "IX_Zbor_AeroportID",
                table: "Zbor",
                newName: "IX_Zbor_Aeroport_plecareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zbor_Aeroport_Aeroport_plecareID",
                table: "Zbor",
                column: "Aeroport_plecareID",
                principalTable: "Aeroport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
