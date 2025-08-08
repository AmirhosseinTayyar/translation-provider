using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.RenameTable(
                name: "Translation",
                newName: "Translation",
                newSchema: "app");

            migrationBuilder.RenameTable(
                name: "Culture",
                newName: "Culture",
                newSchema: "app");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Translation",
                schema: "app",
                newName: "Translation");

            migrationBuilder.RenameTable(
                name: "Culture",
                schema: "app",
                newName: "Culture");
        }
    }
}
