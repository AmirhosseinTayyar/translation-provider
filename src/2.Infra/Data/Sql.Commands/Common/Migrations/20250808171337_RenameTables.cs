using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationProvider.Infra.Data.Sql.Commands.Common.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Translation",
                schema: "app",
                table: "Translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Culture",
                schema: "app",
                table: "Culture");

            migrationBuilder.RenameTable(
                name: "Translation",
                schema: "app",
                newName: "Translations",
                newSchema: "app");

            migrationBuilder.RenameTable(
                name: "Culture",
                schema: "app",
                newName: "Cultures",
                newSchema: "app");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_BusinessId",
                schema: "app",
                table: "Translations",
                newName: "IX_Translations_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Culture_Key",
                schema: "app",
                table: "Cultures",
                newName: "IX_Cultures_Key");

            migrationBuilder.RenameIndex(
                name: "IX_Culture_BusinessId",
                schema: "app",
                table: "Cultures",
                newName: "IX_Cultures_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translations",
                schema: "app",
                table: "Translations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultures",
                schema: "app",
                table: "Cultures",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Translations",
                schema: "app",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultures",
                schema: "app",
                table: "Cultures");

            migrationBuilder.RenameTable(
                name: "Translations",
                schema: "app",
                newName: "Translation",
                newSchema: "app");

            migrationBuilder.RenameTable(
                name: "Cultures",
                schema: "app",
                newName: "Culture",
                newSchema: "app");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_BusinessId",
                schema: "app",
                table: "Translation",
                newName: "IX_Translation_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Cultures_Key",
                schema: "app",
                table: "Culture",
                newName: "IX_Culture_Key");

            migrationBuilder.RenameIndex(
                name: "IX_Cultures_BusinessId",
                schema: "app",
                table: "Culture",
                newName: "IX_Culture_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translation",
                schema: "app",
                table: "Translation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Culture",
                schema: "app",
                table: "Culture",
                column: "Id");
        }
    }
}
