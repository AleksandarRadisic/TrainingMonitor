using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingMonitor.Persistence.Migrations
{
    public partial class AddedTrainingNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "Trainings",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "Trainings");
        }
    }
}
