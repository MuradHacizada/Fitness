using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FittnessWeb.Migrations
{
    public partial class AddColumnTrainerTableNumberAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Trainers");
        }
    }
}
