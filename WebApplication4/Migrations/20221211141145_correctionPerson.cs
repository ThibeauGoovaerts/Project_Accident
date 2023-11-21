using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    public partial class correctionPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Persons_PersonneID",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_VictimInformations_Persons_PersonneID",
                table: "VictimInformations");

            migrationBuilder.DropTable(
                name: "CorrectifMesureAccidents");

            migrationBuilder.DropTable(
                name: "VictimLesions");

            migrationBuilder.DropTable(
                name: "CorrectifMesures");

            migrationBuilder.DropTable(
                name: "Lesions");

            migrationBuilder.RenameColumn(
                name: "PersonneID",
                table: "VictimInformations",
                newName: "PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_VictimInformations_PersonneID",
                table: "VictimInformations",
                newName: "IX_VictimInformations_PersonID");

            migrationBuilder.RenameColumn(
                name: "PersonneID",
                table: "Reports",
                newName: "PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_PersonneID",
                table: "Reports",
                newName: "IX_Reports_PersonID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeWorkStopped",
                table: "VictimInformations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeWorkResumed",
                table: "VictimInformations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "LesionSeats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesionSeats", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NatureLesions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureLesions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProposedMesures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposedMesures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LesionSeatDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LesionSeatID = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesionSeatDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LesionSeatDetails_LesionSeats_LesionSeatID",
                        column: x => x.LesionSeatID,
                        principalTable: "LesionSeats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NatureLesionDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatureLesionID = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureLesionDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NatureLesionDetails_NatureLesions_NatureLesionID",
                        column: x => x.NatureLesionID,
                        principalTable: "NatureLesions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposedMesureDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposedMesureID = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposedMesureDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProposedMesureDetails_ProposedMesures_ProposedMesureID",
                        column: x => x.ProposedMesureID,
                        principalTable: "ProposedMesures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LesionSeatDetailVictimInformation",
                columns: table => new
                {
                    LesionSeatDetailsID = table.Column<int>(type: "int", nullable: false),
                    VictimInformationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesionSeatDetailVictimInformation", x => new { x.LesionSeatDetailsID, x.VictimInformationID });
                    table.ForeignKey(
                        name: "FK_LesionSeatDetailVictimInformation_LesionSeatDetails_LesionSeatDetailsID",
                        column: x => x.LesionSeatDetailsID,
                        principalTable: "LesionSeatDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LesionSeatDetailVictimInformation_VictimInformations_VictimInformationID",
                        column: x => x.VictimInformationID,
                        principalTable: "VictimInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NatureLesionDetailVictimInformation",
                columns: table => new
                {
                    NatureLesionDetailsID = table.Column<int>(type: "int", nullable: false),
                    VictimInformationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureLesionDetailVictimInformation", x => new { x.NatureLesionDetailsID, x.VictimInformationID });
                    table.ForeignKey(
                        name: "FK_NatureLesionDetailVictimInformation_NatureLesionDetails_NatureLesionDetailsID",
                        column: x => x.NatureLesionDetailsID,
                        principalTable: "NatureLesionDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NatureLesionDetailVictimInformation_VictimInformations_VictimInformationID",
                        column: x => x.VictimInformationID,
                        principalTable: "VictimInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccidentProposedMesureDetail",
                columns: table => new
                {
                    AccidentsID = table.Column<int>(type: "int", nullable: false),
                    ProposedMesureDetailsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentProposedMesureDetail", x => new { x.AccidentsID, x.ProposedMesureDetailsID });
                    table.ForeignKey(
                        name: "FK_AccidentProposedMesureDetail_Accidents_AccidentsID",
                        column: x => x.AccidentsID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentProposedMesureDetail_ProposedMesureDetails_ProposedMesureDetailsID",
                        column: x => x.ProposedMesureDetailsID,
                        principalTable: "ProposedMesureDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccidentProposedMesureDetail_ProposedMesureDetailsID",
                table: "AccidentProposedMesureDetail",
                column: "ProposedMesureDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_LesionSeatDetails_LesionSeatID",
                table: "LesionSeatDetails",
                column: "LesionSeatID");

            migrationBuilder.CreateIndex(
                name: "IX_LesionSeatDetailVictimInformation_VictimInformationID",
                table: "LesionSeatDetailVictimInformation",
                column: "VictimInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_NatureLesionDetails_NatureLesionID",
                table: "NatureLesionDetails",
                column: "NatureLesionID");

            migrationBuilder.CreateIndex(
                name: "IX_NatureLesionDetailVictimInformation_VictimInformationID",
                table: "NatureLesionDetailVictimInformation",
                column: "VictimInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedMesureDetails_ProposedMesureID",
                table: "ProposedMesureDetails",
                column: "ProposedMesureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Persons_PersonID",
                table: "Reports",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VictimInformations_Persons_PersonID",
                table: "VictimInformations",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Persons_PersonID",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_VictimInformations_Persons_PersonID",
                table: "VictimInformations");

            migrationBuilder.DropTable(
                name: "AccidentProposedMesureDetail");

            migrationBuilder.DropTable(
                name: "LesionSeatDetailVictimInformation");

            migrationBuilder.DropTable(
                name: "NatureLesionDetailVictimInformation");

            migrationBuilder.DropTable(
                name: "ProposedMesureDetails");

            migrationBuilder.DropTable(
                name: "LesionSeatDetails");

            migrationBuilder.DropTable(
                name: "NatureLesionDetails");

            migrationBuilder.DropTable(
                name: "ProposedMesures");

            migrationBuilder.DropTable(
                name: "LesionSeats");

            migrationBuilder.DropTable(
                name: "NatureLesions");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "VictimInformations",
                newName: "PersonneID");

            migrationBuilder.RenameIndex(
                name: "IX_VictimInformations_PersonID",
                table: "VictimInformations",
                newName: "IX_VictimInformations_PersonneID");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Reports",
                newName: "PersonneID");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_PersonID",
                table: "Reports",
                newName: "IX_Reports_PersonneID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeWorkStopped",
                table: "VictimInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeWorkResumed",
                table: "VictimInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CorrectifMesures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectifMesures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lesions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CorrectifMesureAccidents",
                columns: table => new
                {
                    AccidentID = table.Column<int>(type: "int", nullable: false),
                    CorrectifMesureID = table.Column<int>(type: "int", nullable: false),
                    Proposition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectifMesureAccidents", x => new { x.AccidentID, x.CorrectifMesureID });
                    table.ForeignKey(
                        name: "FK_CorrectifMesureAccidents_Accidents_AccidentID",
                        column: x => x.AccidentID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorrectifMesureAccidents_CorrectifMesures_CorrectifMesureID",
                        column: x => x.CorrectifMesureID,
                        principalTable: "CorrectifMesures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VictimLesions",
                columns: table => new
                {
                    LesionID = table.Column<int>(type: "int", nullable: false),
                    VictimID = table.Column<int>(type: "int", nullable: false),
                    LesionDetail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictimLesions", x => new { x.LesionID, x.VictimID });
                    table.ForeignKey(
                        name: "FK_VictimLesions_Lesions_LesionID",
                        column: x => x.LesionID,
                        principalTable: "Lesions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VictimLesions_VictimInformations_VictimID",
                        column: x => x.VictimID,
                        principalTable: "VictimInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectifMesureAccidents_CorrectifMesureID",
                table: "CorrectifMesureAccidents",
                column: "CorrectifMesureID");

            migrationBuilder.CreateIndex(
                name: "IX_VictimLesions_VictimID",
                table: "VictimLesions",
                column: "VictimID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Persons_PersonneID",
                table: "Reports",
                column: "PersonneID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VictimInformations_Persons_PersonneID",
                table: "VictimInformations",
                column: "PersonneID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
