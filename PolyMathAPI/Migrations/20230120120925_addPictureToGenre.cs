using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolyMathAPI.Migrations
{
    public partial class addPictureToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Genres",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Genres");
        }
    }
}
