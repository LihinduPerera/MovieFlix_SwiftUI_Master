using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFlix.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdduniqueTmdbIdIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movies_TmdbId",
                table: "Movies",
                column: "TmdbId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_TmdbId",
                table: "Movies");
        }
    }
}
