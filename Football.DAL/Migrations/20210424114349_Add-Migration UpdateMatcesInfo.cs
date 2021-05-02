using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DAL.Migrations
{
    public partial class AddMigrationUpdateMatcesInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Team2_Goals",
                table: "Matches",
                newName: "Team2Goals");

            migrationBuilder.RenameColumn(
                name: "Team1_Goals",
                table: "Matches",
                newName: "Team1Goals");

            migrationBuilder.AddColumn<int>(
                name: "MatchLocation",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchTournamentId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Outcome",
                table: "Matches",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TicketSales",
                table: "Matches",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatchTournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultPayment = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTournament", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchTournamentId",
                table: "Matches",
                column: "MatchTournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchTournament_MatchTournamentId",
                table: "Matches",
                column: "MatchTournamentId",
                principalTable: "MatchTournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchTournament_MatchTournamentId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "MatchTournament");

            migrationBuilder.DropIndex(
                name: "IX_Matches_MatchTournamentId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchLocation",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchTournamentId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Outcome",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TicketSales",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Team2Goals",
                table: "Matches",
                newName: "Team2_Goals");

            migrationBuilder.RenameColumn(
                name: "Team1Goals",
                table: "Matches",
                newName: "Team1_Goals");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Matches",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
