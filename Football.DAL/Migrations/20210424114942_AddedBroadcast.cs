using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DAL.Migrations
{
    public partial class AddedBroadcast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchTournament_MatchTournamentId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchTournament",
                table: "MatchTournament");

            migrationBuilder.RenameTable(
                name: "MatchTournament",
                newName: "MatchTournaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchTournaments",
                table: "MatchTournaments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MatchBroadcasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchTournamentId = table.Column<int>(type: "int", nullable: false),
                    Payment = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchBroadcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchBroadcasts_MatchTournaments_MatchTournamentId",
                        column: x => x.MatchTournamentId,
                        principalTable: "MatchTournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchBroadcasts_MatchTournamentId",
                table: "MatchBroadcasts",
                column: "MatchTournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchTournaments_MatchTournamentId",
                table: "Matches",
                column: "MatchTournamentId",
                principalTable: "MatchTournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchTournaments_MatchTournamentId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "MatchBroadcasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchTournaments",
                table: "MatchTournaments");

            migrationBuilder.RenameTable(
                name: "MatchTournaments",
                newName: "MatchTournament");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchTournament",
                table: "MatchTournament",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchTournament_MatchTournamentId",
                table: "Matches",
                column: "MatchTournamentId",
                principalTable: "MatchTournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
