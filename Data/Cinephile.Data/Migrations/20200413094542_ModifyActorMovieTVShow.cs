using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinephile.Data.Migrations
{
    public partial class ModifyActorMovieTVShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "TVShows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "TVShows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Creater",
                table: "TVShows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TVShows",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "TVShows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePageLink",
                table: "TVShows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMDBLink",
                table: "TVShows",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "TVShows",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrailerLink",
                table: "TVShows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "TVShows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Creater",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePageLink",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMDBLink",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrailerLink",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Birthplace",
                table: "Actors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Actors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Actors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePageLink",
                table: "Actors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMDBLink",
                table: "Actors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_ActorId",
                table: "TVShows",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ActorId",
                table: "Movies",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_ActorId",
                table: "Movies",
                column: "ActorId",
                principalTable: "Actors",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_ActorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShows_Actors_ActorId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_TVShows_ActorId",
                table: "TVShows");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ActorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Creater",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "HomePageLink",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "IMDBLink",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "TrailerLink",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Creater",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "HomePageLink",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IMDBLink",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TrailerLink",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Birthplace",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "HomePageLink",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "IMDBLink",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                table: "TVShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseYear",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
