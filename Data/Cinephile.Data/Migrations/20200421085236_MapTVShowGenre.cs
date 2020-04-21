using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinephile.Data.Migrations
{
    public partial class MapTVShowGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShows_Genres_GenreId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_TVShows_GenreId",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "TVShows");

            migrationBuilder.CreateTable(
                name: "TVShowGenres",
                columns: table => new
                {
                    TVShowId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowGenres", x => new { x.TVShowId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_TVShowGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TVShowGenres_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVShowGenres_GenreId",
                table: "TVShowGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVShowGenres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "TVShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_GenreId",
                table: "TVShows",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShows_Genres_GenreId",
                table: "TVShows",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
