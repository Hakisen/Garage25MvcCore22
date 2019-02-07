using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage25MvcCore22.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Receipt");

            migrationBuilder.AddColumn<string>(
                name: "ParkedTimeFormatted",
                table: "Receipt",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parkedTime",
                table: "Receipt",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkedTimeFormatted",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "parkedTime",
                table: "Receipt");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Receipt",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
