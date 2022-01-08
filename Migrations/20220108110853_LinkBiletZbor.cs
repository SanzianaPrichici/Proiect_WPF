using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_WPF.Migrations
{
    public partial class LinkBiletZbor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zbor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zbor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TicketFlight",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiletID = table.Column<int>(type: "int", nullable: false),
                    ZborID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFlight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TicketFlight_Bilet_BiletID",
                        column: x => x.BiletID,
                        principalTable: "Bilet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketFlight_Zbor_ZborID",
                        column: x => x.ZborID,
                        principalTable: "Zbor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketFlight_BiletID",
                table: "TicketFlight",
                column: "BiletID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFlight_ZborID",
                table: "TicketFlight",
                column: "ZborID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketFlight");

            migrationBuilder.DropTable(
                name: "Zbor");
        }
    }
}
