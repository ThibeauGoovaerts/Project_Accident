using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorrectifMesures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectifMesures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Deviations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deviations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DirectMesures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectMesures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FundamentaryCauses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundamentaryCauses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lesions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialAgents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialAgents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OutsideFirms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutsideFirms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Protections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protections", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeviationDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviationID = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviationDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeviationDetails_Deviations_DeviationID",
                        column: x => x.DeviationID,
                        principalTable: "Deviations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accidents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Probability = table.Column<int>(type: "int", nullable: false),
                    Gravity = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accidents_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialAgentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialAgentID = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialAgentDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialAgentDetails_MaterialAgents_MaterialAgentID",
                        column: x => x.MaterialAgentID,
                        principalTable: "MaterialAgents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutsideFirmID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persons_OutsideFirms_OutsideFirmID",
                        column: x => x.OutsideFirmID,
                        principalTable: "OutsideFirms",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AccidentDeviationDetail",
                columns: table => new
                {
                    AccidentsID = table.Column<int>(type: "int", nullable: false),
                    DeviationDetailsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentDeviationDetail", x => new { x.AccidentsID, x.DeviationDetailsID });
                    table.ForeignKey(
                        name: "FK_AccidentDeviationDetail_Accidents_AccidentsID",
                        column: x => x.AccidentsID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentDeviationDetail_DeviationDetails_DeviationDetailsID",
                        column: x => x.DeviationDetailsID,
                        principalTable: "DeviationDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccidentDirectMesure",
                columns: table => new
                {
                    AccidentsID = table.Column<int>(type: "int", nullable: false),
                    DirectMesuresID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentDirectMesure", x => new { x.AccidentsID, x.DirectMesuresID });
                    table.ForeignKey(
                        name: "FK_AccidentDirectMesure_Accidents_AccidentsID",
                        column: x => x.AccidentsID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentDirectMesure_DirectMesures_DirectMesuresID",
                        column: x => x.DirectMesuresID,
                        principalTable: "DirectMesures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccidentFundamentaryCause",
                columns: table => new
                {
                    AccidentsID = table.Column<int>(type: "int", nullable: false),
                    FundamentaryCausesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentFundamentaryCause", x => new { x.AccidentsID, x.FundamentaryCausesID });
                    table.ForeignKey(
                        name: "FK_AccidentFundamentaryCause_Accidents_AccidentsID",
                        column: x => x.AccidentsID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentFundamentaryCause_FundamentaryCauses_FundamentaryCausesID",
                        column: x => x.FundamentaryCausesID,
                        principalTable: "FundamentaryCauses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorrectifMesureAccidents",
                columns: table => new
                {
                    CorrectifMesureID = table.Column<int>(type: "int", nullable: false),
                    AccidentID = table.Column<int>(type: "int", nullable: false),
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
                name: "AccidentMaterialAgentDetail",
                columns: table => new
                {
                    AccidentsID = table.Column<int>(type: "int", nullable: false),
                    MaterialAgentDetailsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentMaterialAgentDetail", x => new { x.AccidentsID, x.MaterialAgentDetailsID });
                    table.ForeignKey(
                        name: "FK_AccidentMaterialAgentDetail_Accidents_AccidentsID",
                        column: x => x.AccidentsID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentMaterialAgentDetail_MaterialAgentDetails_MaterialAgentDetailsID",
                        column: x => x.MaterialAgentDetailsID,
                        principalTable: "MaterialAgentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentID = table.Column<int>(type: "int", nullable: false),
                    PersonneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reports_Accidents_AccidentID",
                        column: x => x.AccidentID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Persons_PersonneID",
                        column: x => x.PersonneID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VictimInformations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkStopped = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeWorkStopped = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccidentID = table.Column<int>(type: "int", nullable: false),
                    WorkResumed = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeWorkResumed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsualFunction = table.Column<bool>(type: "bit", nullable: false),
                    ActivityDuringAccident = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictimInformations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VictimInformations_Accidents_AccidentID",
                        column: x => x.AccidentID,
                        principalTable: "Accidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VictimInformations_Persons_PersonneID",
                        column: x => x.PersonneID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VictimLesions",
                columns: table => new
                {
                    VictimID = table.Column<int>(type: "int", nullable: false),
                    LesionID = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "VictimProtectionAssets",
                columns: table => new
                {
                    VictimInformationID = table.Column<int>(type: "int", nullable: false),
                    ProtectionID = table.Column<int>(type: "int", nullable: false),
                    isNecessary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictimProtectionAssets", x => new { x.VictimInformationID, x.ProtectionID });
                    table.ForeignKey(
                        name: "FK_VictimProtectionAssets_Protections_ProtectionID",
                        column: x => x.ProtectionID,
                        principalTable: "Protections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VictimProtectionAssets_VictimInformations_VictimInformationID",
                        column: x => x.VictimInformationID,
                        principalTable: "VictimInformations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccidentDeviationDetail_DeviationDetailsID",
                table: "AccidentDeviationDetail",
                column: "DeviationDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentDirectMesure_DirectMesuresID",
                table: "AccidentDirectMesure",
                column: "DirectMesuresID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentFundamentaryCause_FundamentaryCausesID",
                table: "AccidentFundamentaryCause",
                column: "FundamentaryCausesID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentMaterialAgentDetail_MaterialAgentDetailsID",
                table: "AccidentMaterialAgentDetail",
                column: "MaterialAgentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_LocationID",
                table: "Accidents",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectifMesureAccidents_CorrectifMesureID",
                table: "CorrectifMesureAccidents",
                column: "CorrectifMesureID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviationDetails_DeviationID",
                table: "DeviationDetails",
                column: "DeviationID");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAgentDetails_MaterialAgentID",
                table: "MaterialAgentDetails",
                column: "MaterialAgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OutsideFirmID",
                table: "Persons",
                column: "OutsideFirmID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AccidentID",
                table: "Reports",
                column: "AccidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PersonneID",
                table: "Reports",
                column: "PersonneID");

            migrationBuilder.CreateIndex(
                name: "IX_VictimInformations_AccidentID",
                table: "VictimInformations",
                column: "AccidentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VictimInformations_PersonneID",
                table: "VictimInformations",
                column: "PersonneID");

            migrationBuilder.CreateIndex(
                name: "IX_VictimLesions_VictimID",
                table: "VictimLesions",
                column: "VictimID");

            migrationBuilder.CreateIndex(
                name: "IX_VictimProtectionAssets_ProtectionID",
                table: "VictimProtectionAssets",
                column: "ProtectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccidentDeviationDetail");

            migrationBuilder.DropTable(
                name: "AccidentDirectMesure");

            migrationBuilder.DropTable(
                name: "AccidentFundamentaryCause");

            migrationBuilder.DropTable(
                name: "AccidentMaterialAgentDetail");

            migrationBuilder.DropTable(
                name: "CorrectifMesureAccidents");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "VictimLesions");

            migrationBuilder.DropTable(
                name: "VictimProtectionAssets");

            migrationBuilder.DropTable(
                name: "DeviationDetails");

            migrationBuilder.DropTable(
                name: "DirectMesures");

            migrationBuilder.DropTable(
                name: "FundamentaryCauses");

            migrationBuilder.DropTable(
                name: "MaterialAgentDetails");

            migrationBuilder.DropTable(
                name: "CorrectifMesures");

            migrationBuilder.DropTable(
                name: "Lesions");

            migrationBuilder.DropTable(
                name: "Protections");

            migrationBuilder.DropTable(
                name: "VictimInformations");

            migrationBuilder.DropTable(
                name: "Deviations");

            migrationBuilder.DropTable(
                name: "MaterialAgents");

            migrationBuilder.DropTable(
                name: "Accidents");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OutsideFirms");
        }
    }
}
