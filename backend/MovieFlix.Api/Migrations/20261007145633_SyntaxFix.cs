using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlix.Api.Migrations
{
    /// <inheritdoc />
    public partial class SyntaxFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateedAt",
                table: "Users",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "CreateedAt");
        }
    }
}
