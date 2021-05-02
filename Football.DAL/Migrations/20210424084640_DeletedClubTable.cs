using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DAL.Migrations
{
    public partial class DeletedClubTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Club_Club_Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Club_Club_Id",
                table: "Player");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropIndex(
                name: "IX_Player_Club_Id",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Club_Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Club_Id",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Club_Id",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Club_Id",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Club_Id",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    budget = table.Column<double>(type: "float", nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    year_founded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_Club_Id",
                table: "Player",
                column: "Club_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Club_Id",
                table: "Matches",
                column: "Club_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Club_Club_Id",
                table: "Matches",
                column: "Club_Id",
                principalTable: "Club",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Club_Club_Id",
                table: "Player",
                column: "Club_Id",
                principalTable: "Club",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
