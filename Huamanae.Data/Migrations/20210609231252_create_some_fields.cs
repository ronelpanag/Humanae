using Microsoft.EntityFrameworkCore.Migrations;

namespace Humanae.Data.Migrations
{
    public partial class create_some_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Applicants");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Applicants",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Applicants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChosen",
                table: "Applicants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Applicants",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ApplicantId",
                table: "Employees",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Applicants_ApplicantId",
                table: "Employees",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Applicants_ApplicantId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ApplicantId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "IsChosen",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Applicants");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
