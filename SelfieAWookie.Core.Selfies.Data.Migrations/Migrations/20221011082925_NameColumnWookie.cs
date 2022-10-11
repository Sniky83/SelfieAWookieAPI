using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookie.Core.Selfies.Data.Migrations.Migrations
{
    public partial class NameColumnWookie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Wookie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Wookie");
        }
    }
}
