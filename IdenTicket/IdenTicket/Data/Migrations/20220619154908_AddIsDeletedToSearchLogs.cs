using Microsoft.EntityFrameworkCore.Migrations;

namespace IdenTicket.Migrations
{
    public partial class AddIsDeletedToSearchLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SearchLogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SearchLogs");
        }
    }
}
