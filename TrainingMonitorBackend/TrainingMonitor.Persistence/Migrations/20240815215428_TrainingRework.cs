using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingMonitor.Persistence.Migrations
{
    public partial class TrainingRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingType",
                table: "Trainings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "Trainings");
        }
    }
}
