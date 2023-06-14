using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FittnessWeb.Migrations
{
    public partial class AddColumnTrainerImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Trainers");
        }
    }
}
