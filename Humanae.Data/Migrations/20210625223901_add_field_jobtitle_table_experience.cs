using Microsoft.EntityFrameworkCore.Migrations;

namespace Humanae.Data.Migrations
{
    public partial class add_field_jobtitle_table_experience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Experiences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Experiences");
        }
    }
}
