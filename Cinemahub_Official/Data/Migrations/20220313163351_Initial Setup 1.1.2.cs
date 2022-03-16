using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinemahub_Official.Data.Migrations
{
    public partial class InitialSetup112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Actor1",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Actor2",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Actor3",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actor1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Actor2",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Actor3",
                table: "Movies");
        }
    }
}
