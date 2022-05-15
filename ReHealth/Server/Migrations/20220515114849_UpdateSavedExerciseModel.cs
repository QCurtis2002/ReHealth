using Microsoft.EntityFrameworkCore.Migrations;

namespace ReHealth.Server.Migrations
{
    public partial class UpdateSavedExerciseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExerciseGifUrl",
                table: "SavedExercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "SavedExercise",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseGifUrl",
                table: "SavedExercise");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "SavedExercise");
        }
    }
}
