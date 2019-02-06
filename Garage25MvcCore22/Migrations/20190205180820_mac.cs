using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage25MvcCore22.Migrations
{
    public partial class mac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "VehicleType",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "VehicleType",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
