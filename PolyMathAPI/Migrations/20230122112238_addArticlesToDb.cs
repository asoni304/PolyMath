using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolyMathAPI.Migrations
{
    public partial class addArticlesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: true),
                    Author = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_GenreId",
                table: "Articles",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
