using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema_task.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cinemas",
                newName: "CinemaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Cinemas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Categories",
                newName: "Id");
        }
    }
}
