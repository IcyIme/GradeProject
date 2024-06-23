using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeProject.Migrations
{
    /// <inheritdoc />
    public partial class roomss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "ForumRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "ForumRooms");
        }
    }
}
