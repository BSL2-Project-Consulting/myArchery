using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myArchery.Persistance.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcours",
                columns: table => new
                {
                    ParId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parcourname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postalcode = table.Column<int>(type: "int", nullable: false),
                    StreetHousenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Counttargets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcours", x => x.ParId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    TarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Targetname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.TarId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isactive = table.Column<int>(type: "int", nullable: false),
                    Getnewsletter = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UseId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eventname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrowamount = table.Column<int>(type: "int", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isprivat = table.Column<short>(type: "smallint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EveId);
                    table.ForeignKey(
                        name: "FK_Events_Parcours_ParId",
                        column: x => x.ParId,
                        principalTable: "Parcours",
                        principalColumn: "ParId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcoursTargets",
                columns: table => new
                {
                    PataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParId = table.Column<int>(type: "int", nullable: false),
                    TarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcoursTargets", x => x.PataId);
                    table.ForeignKey(
                        name: "FK_ParcoursTargets_Parcours_ParId",
                        column: x => x.ParId,
                        principalTable: "Parcours",
                        principalColumn: "ParId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcoursTargets_Targets_TarId",
                        column: x => x.TarId,
                        principalTable: "Targets",
                        principalColumn: "TarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordHistories",
                columns: table => new
                {
                    PhyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fromdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Untildate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    UseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistories", x => x.PhyId);
                    table.ForeignKey(
                        name: "FK_PasswordHistories_Users_UseId",
                        column: x => x.UseId,
                        principalTable: "Users",
                        principalColumn: "UseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventUserRoles",
                columns: table => new
                {
                    EvusroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EveId = table.Column<int>(type: "int", nullable: false),
                    UseId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUserRoles", x => x.EvusroId);
                    table.ForeignKey(
                        name: "FK_EventUserRoles_Events_EveId",
                        column: x => x.EveId,
                        principalTable: "Events",
                        principalColumn: "EveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUserRoles_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUserRoles_Users_UseId",
                        column: x => x.UseId,
                        principalTable: "Users",
                        principalColumn: "UseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EveId = table.Column<int>(type: "int", nullable: false),
                    ValueId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PoiId);
                    table.ForeignKey(
                        name: "FK_Points_Events_EveId",
                        column: x => x.EveId,
                        principalTable: "Events",
                        principalColumn: "EveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arrows",
                columns: table => new
                {
                    ArrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoiId = table.Column<int>(type: "int", nullable: false),
                    PataId = table.Column<int>(type: "int", nullable: false),
                    EvusroId = table.Column<int>(type: "int", nullable: false),
                    Hitdatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrows", x => x.ArrId);
                    table.ForeignKey(
                        name: "FK_Arrows_EventUserRoles_EvusroId",
                        column: x => x.EvusroId,
                        principalTable: "EventUserRoles",
                        principalColumn: "EvusroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arrows_ParcoursTargets_PataId",
                        column: x => x.PataId,
                        principalTable: "ParcoursTargets",
                        principalColumn: "PataId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arrows_Points_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Points",
                        principalColumn: "PoiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrows_EvusroId",
                table: "Arrows",
                column: "EvusroId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrows_PataId",
                table: "Arrows",
                column: "PataId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrows_PoiId",
                table: "Arrows",
                column: "PoiId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ParId",
                table: "Events",
                column: "ParId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserRoles_EveId",
                table: "EventUserRoles",
                column: "EveId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserRoles_RolId",
                table: "EventUserRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserRoles_UseId",
                table: "EventUserRoles",
                column: "UseId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcoursTargets_ParId",
                table: "ParcoursTargets",
                column: "ParId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcoursTargets_TarId",
                table: "ParcoursTargets",
                column: "TarId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistories_UseId",
                table: "PasswordHistories",
                column: "UseId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_EveId",
                table: "Points",
                column: "EveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrows");

            migrationBuilder.DropTable(
                name: "PasswordHistories");

            migrationBuilder.DropTable(
                name: "EventUserRoles");

            migrationBuilder.DropTable(
                name: "ParcoursTargets");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Parcours");
        }
    }
}
