using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingAppPac3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Gamer",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InGameName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamer", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Gamer_Game",
                columns: table => new
                {
                    GGKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GamerUserID = table.Column<int>(type: "int", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamer_Game", x => x.GGKey);
                    table.ForeignKey(
                        name: "FK_Gamer_Game_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gamer_Game_Gamer_GamerUserID",
                        column: x => x.GamerUserID,
                        principalTable: "Gamer",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gamer_Game_GameID",
                table: "Gamer_Game",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Gamer_Game_GamerUserID",
                table: "Gamer_Game",
                column: "GamerUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gamer_Game");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Gamer");
        }
    }
}
