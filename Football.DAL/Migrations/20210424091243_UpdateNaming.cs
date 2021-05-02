using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DAL.Migrations
{
    public partial class UpdateNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Contracts_Contract_Id",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatches_Matches_Match_Id",
                table: "PlayerMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatches_Player_Player_Id",
                table: "PlayerMatches");

            migrationBuilder.DropIndex(
                name: "IX_Player_Contract_Id",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "Match_Id",
                table: "PlayerMatches",
                newName: "MatchId");

            migrationBuilder.RenameColumn(
                name: "Player_Id",
                table: "PlayerMatches",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMatches_Match_Id",
                table: "PlayerMatches",
                newName: "IX_PlayerMatches_MatchId");

            migrationBuilder.RenameColumn(
                name: "Contract_Id",
                table: "Player",
                newName: "ContractId");

            migrationBuilder.RenameColumn(
                name: "Club_Enemy_Name",
                table: "Matches",
                newName: "ClubEnemyName");

            migrationBuilder.CreateIndex(
                name: "IX_Player_ContractId",
                table: "Player",
                column: "ContractId",
                unique: true,
                filter: "[ContractId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Contracts_ContractId",
                table: "Player",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatches_Matches_MatchId",
                table: "PlayerMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatches_Player_PlayerId",
                table: "PlayerMatches",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Contracts_ContractId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatches_Matches_MatchId",
                table: "PlayerMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatches_Player_PlayerId",
                table: "PlayerMatches");

            migrationBuilder.DropIndex(
                name: "IX_Player_ContractId",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "PlayerMatches",
                newName: "Match_Id");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "PlayerMatches",
                newName: "Player_Id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMatches_MatchId",
                table: "PlayerMatches",
                newName: "IX_PlayerMatches_Match_Id");

            migrationBuilder.RenameColumn(
                name: "ContractId",
                table: "Player",
                newName: "Contract_Id");

            migrationBuilder.RenameColumn(
                name: "ClubEnemyName",
                table: "Matches",
                newName: "Club_Enemy_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Contract_Id",
                table: "Player",
                column: "Contract_Id",
                unique: true,
                filter: "[Contract_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Contracts_Contract_Id",
                table: "Player",
                column: "Contract_Id",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatches_Matches_Match_Id",
                table: "PlayerMatches",
                column: "Match_Id",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatches_Player_Player_Id",
                table: "PlayerMatches",
                column: "Player_Id",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
