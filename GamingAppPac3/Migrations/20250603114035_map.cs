using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingAppPac3.Migrations
{
    /// <inheritdoc />
    public partial class map : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Gamer",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Gamer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Gamer",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Gamer");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Gamer");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Gamer");
        }
    }
}
