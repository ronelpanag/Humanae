using Microsoft.EntityFrameworkCore.Migrations;

namespace Humanae.Data.Migrations
{
    public partial class finishingmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApplicantTrainings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApplicantSkills",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApplicantLanguages",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApplicantExperiences",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantTrainings",
                table: "ApplicantTrainings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantSkills",
                table: "ApplicantSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantLanguages",
                table: "ApplicantLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantExperiences",
                table: "ApplicantExperiences",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantTrainings",
                table: "ApplicantTrainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantSkills",
                table: "ApplicantSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantLanguages",
                table: "ApplicantLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantExperiences",
                table: "ApplicantExperiences");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicantTrainings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicantSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicantLanguages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicantExperiences");
        }
    }
}
