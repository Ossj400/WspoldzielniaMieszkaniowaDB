using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WspoldzielniaMieszkaniowaDB.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electricians",
                columns: table => new
                {
                    Electrician_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EL_FIRTS_NAME = table.Column<string>(maxLength: 20, nullable: false),
                    EL_LAST_NAME = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electricians", x => x.Electrician_ID);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    FAMILY_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilySurname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.FAMILY_ID);
                });

            migrationBuilder.CreateTable(
                name: "OSIEDLA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaOsiedla = table.Column<string>(nullable: true),
                    WskaźnikRentowności = table.Column<string>(nullable: false),
                    TypSpółdzielni = table.Column<string>(nullable: false),
                    NumerBloku = table.Column<int>(nullable: true),
                    Ulica = table.Column<string>(maxLength: 80, nullable: true),
                    NrKlatki = table.Column<string>(maxLength: 5, nullable: true),
                    OplatyZaMediaWspoldzielone = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSIEDLA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    Flat_ID = table.Column<int>(nullable: false),
                    Flat_COST = table.Column<decimal>(type: "money", nullable: false),
                    Family_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.Flat_ID);
                    table.ForeignKey(
                        name: "FK_Flat_Family_Family_ID",
                        column: x => x.Family_ID,
                        principalTable: "Family",
                        principalColumn: "FAMILY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupant",
                columns: table => new
                {
                    Occupant_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 20, nullable: false),
                    SURNAME = table.Column<string>(maxLength: 20, nullable: false),
                    Occupant_Age = table.Column<int>(nullable: false),
                    Family_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupant", x => x.Occupant_ID);
                    table.ForeignKey(
                        name: "FK_Occupant_Family_Family_ID",
                        column: x => x.Family_ID,
                        principalTable: "Family",
                        principalColumn: "FAMILY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basement",
                columns: table => new
                {
                    BASEMENTID = table.Column<int>(name: "BASEMENT ID", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basement", x => x.BASEMENTID);
                    table.ForeignKey(
                        name: "FK_Basement_Flat_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flat",
                        principalColumn: "Flat_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Electric_Works",
                columns: table => new
                {
                    WorkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flat_ID = table.Column<int>(nullable: false),
                    COST = table.Column<decimal>(type: "money", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electric_Works", x => x.WorkID);
                    table.UniqueConstraint("AK_Electric_Works_Flat_ID", x => x.Flat_ID);
                    table.UniqueConstraint("AK_Electric_Works_Flat_ID_WorkID", x => new { x.Flat_ID, x.WorkID });
                    table.ForeignKey(
                        name: "FK_Electric_Works_Flat_Flat_ID",
                        column: x => x.Flat_ID,
                        principalTable: "Flat",
                        principalColumn: "Flat_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricianJob",
                columns: table => new
                {
                    Electrician_ID = table.Column<int>(nullable: false),
                    ElectricianWorkID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricianJob", x => new { x.Electrician_ID, x.ElectricianWorkID });
                    table.ForeignKey(
                        name: "FK_ElectricianJob_Electricians_Electrician_ID",
                        column: x => x.Electrician_ID,
                        principalTable: "Electricians",
                        principalColumn: "Electrician_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricianJob_Electric_Works_ElectricianWorkID",
                        column: x => x.ElectricianWorkID,
                        principalTable: "Electric_Works",
                        principalColumn: "WorkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basement_FlatId",
                table: "Basement",
                column: "FlatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricianJob_ElectricianWorkID",
                table: "ElectricianJob",
                column: "ElectricianWorkID");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_Family_ID",
                table: "Flat",
                column: "Family_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occupant_Family_ID",
                table: "Occupant",
                column: "Family_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basement");

            migrationBuilder.DropTable(
                name: "ElectricianJob");

            migrationBuilder.DropTable(
                name: "Occupant");

            migrationBuilder.DropTable(
                name: "OSIEDLA");

            migrationBuilder.DropTable(
                name: "Electricians");

            migrationBuilder.DropTable(
                name: "Electric_Works");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}
