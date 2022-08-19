using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGames.Data.Migrations
{
    public partial class Changesinconfigurationsv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId2",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GenreId2",
                table: "Games",
                newName: "GenreId1");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GenreId2",
                table: "Games",
                newName: "IX_Games_GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId1",
                table: "Games",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId1",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GenreId1",
                table: "Games",
                newName: "GenreId2");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GenreId1",
                table: "Games",
                newName: "IX_Games_GenreId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId2",
                table: "Games",
                column: "GenreId2",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
