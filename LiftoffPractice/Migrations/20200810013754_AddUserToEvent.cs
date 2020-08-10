using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftoffPractice.Migrations
{
    public partial class AddUserToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Materials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Materials");
        }
    }
}
