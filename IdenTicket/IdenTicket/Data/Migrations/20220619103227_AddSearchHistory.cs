using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdenTicket.Migrations
{
    public partial class AddSearchHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(nullable: false),
                    SearchDate = table.Column<DateTime>(nullable: false),
                    DepartureAirport = table.Column<string>(maxLength: 50, nullable: false),
                    DestinationAirport = table.Column<string>(maxLength: 50, nullable: false),
                    DepartDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true),
                    FlightType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchLogs_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchLogs_CustomerId",
                table: "SearchLogs",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchLogs");
        }
    }
}
