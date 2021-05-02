using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DAL.Migrations
{
    public partial class DeleteBehav1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatches_Player_Player_Id",
                table: "PlayerMatches");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatches_Player_Player_Id",
                table: "PlayerMatches",
                column: "Player_Id",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatches_Player_Player_Id",
                table: "PlayerMatches");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatches_Player_Player_Id",
                table: "PlayerMatches",
                column: "Player_Id",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
