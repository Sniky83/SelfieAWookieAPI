using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookie.Core.Selfies.Data.Migrations.Migrations
{
    public partial class AddCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Selfie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Selfie",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Selfie");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Selfie");
        }
    }
}
