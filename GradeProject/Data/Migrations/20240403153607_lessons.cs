using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeProject.Migrations
{
    /// <inheritdoc />
    public partial class lessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompletedLesson",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedLesson",
                table: "AspNetUsers");
        }
    }
}
