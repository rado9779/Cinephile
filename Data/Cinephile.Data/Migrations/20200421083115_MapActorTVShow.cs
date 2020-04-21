using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinephile.Data.Migrations
{
    public partial class MapActorTVShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Actors_TVShows_TVShowId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShows_Actors_ActorId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_TVShows_ActorId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_Actors_MovieId",
                table: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_TVShowId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Actors");

            migrationBuilder.CreateTable(
                name: "ActorTVShows",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false),
                    TVShowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorTVShows", x => new { x.ActorId, x.TVShowId });
                    table.ForeignKey(
                        name: "FK_ActorTVShows_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorTVShows_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorTVShows_TVShowId",
                table: "ActorTVShows",
                column: "TVShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorTVShows");

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "TVShows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TVShowId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_ActorId",
                table: "TVShows",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                table: "Actors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_TVShowId",
                table: "Actors",
                column: "TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_TVShows_TVShowId",
                table: "Actors",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShows_Actors_ActorId",
                table: "TVShows",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
