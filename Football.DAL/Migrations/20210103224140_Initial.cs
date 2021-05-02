using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    budget = table.Column<double>(type: "float", nullable: false),
                    year_founded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Premium = table.Column<double>(type: "float", nullable: false),
                    SignedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Club_Id = table.Column<int>(type: "int", nullable: true),
                    Club_Enemy_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Team1_Goals = table.Column<int>(type: "int", nullable: false),
                    Team2_Goals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Club_Club_Id",
                        column: x => x.Club_Id,
                        principalTable: "Club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "CM"),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCaptain = table.Column<bool>(type: "bit", nullable: false),
                    Club_Id = table.Column<int>(type: "int", nullable: true),
                    Contract_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Club_Club_Id",
                        column: x => x.Club_Id,
                        principalTable: "Club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Contracts_Contract_Id",
                        column: x => x.Contract_Id,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatches",
                columns: table => new
                {
                    Match_Id = table.Column<int>(type: "int", nullable: false),
                    Player_Id = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatches", x => new { x.Player_Id, x.Match_Id });
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Matches_Match_Id",
                        column: x => x.Match_Id,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Player_Player_Id",
                        column: x => x.Player_Id,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Club_Id",
                table: "Matches",
                column: "Club_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Club_Id",
                table: "Player",
                column: "Club_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Contract_Id",
                table: "Player",
                column: "Contract_Id",
                unique: true,
                filter: "[Contract_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_Match_Id",
                table: "PlayerMatches",
                column: "Match_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerMatches");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
