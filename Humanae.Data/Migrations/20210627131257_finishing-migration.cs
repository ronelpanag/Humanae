using Microsoft.EntityFrameworkCore.Migrations;

namespace Humanae.Data.Migrations
{
    public partial class finishingmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RiskLevel",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RiskLevel",
                table: "Positions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
