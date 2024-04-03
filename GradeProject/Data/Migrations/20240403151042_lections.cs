using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeProject.Migrations
{
    /// <inheritdoc />
    public partial class lections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompletedLections",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedLections",
                table: "AspNetUsers");
        }
    }
}
