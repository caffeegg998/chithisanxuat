using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductionDirectives.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiThi_Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: false),
                    NumberOrder = table.Column<int>(type: "integer", nullable: false),
                    Step = table.Column<string>(type: "text", nullable: false),
                    RuleStandard = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiThi_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiThiMaus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    TotalStage = table.Column<int>(type: "integer", nullable: false),
                    TotalStep = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiThiMaus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    First = table.Column<string>(type: "text", nullable: false),
                    Last = table.Column<string>(type: "text", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChiThiMau_ChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    Stage = table.Column<string>(type: "text", nullable: false),
                    NumberOrder = table.Column<int>(type: "integer", nullable: false),
                    Step = table.Column<string>(type: "text", nullable: false),
                    RuleStandard = table.Column<string>(type: "text", nullable: false),
                    Id_ChiThiMau = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiThiMau_ChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiThiMau_ChiTiets_ChiThiMaus_Id_ChiThiMau",
                        column: x => x.Id_ChiThiMau,
                        principalTable: "ChiThiMaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiThiPheDuyets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    TotalStage = table.Column<int>(type: "integer", nullable: false),
                    TotalStep = table.Column<int>(type: "integer", nullable: false),
                    isDandory_Done = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Shift = table.Column<string>(type: "text", nullable: false),
                    PICCreate = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiThiPheDuyets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiThiPheDuyets_NguoiDungs_PICCreate",
                        column: x => x.PICCreate,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiThiPheDuyet_ChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    Stage = table.Column<string>(type: "text", nullable: false),
                    NumberOrder = table.Column<int>(type: "integer", nullable: false),
                    Step = table.Column<string>(type: "text", nullable: false),
                    RuleStandard = table.Column<string>(type: "text", nullable: false),
                    Actual = table.Column<string>(type: "text", nullable: false),
                    Result = table.Column<bool>(type: "boolean", nullable: false),
                    LastChecked = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PICCheckId = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_ChiThiPheDuyet = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiThiPheDuyet_ChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiThiPheDuyet_ChiTiets_ChiThiPheDuyets_Id_ChiThiPheDuyet",
                        column: x => x.Id_ChiThiPheDuyet,
                        principalTable: "ChiThiPheDuyets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiThiPheDuyet_ChiTiets_NguoiDungs_PICCheckId",
                        column: x => x.PICCheckId,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiThiMau_ChiTiets_Id_ChiThiMau",
                table: "ChiThiMau_ChiTiets",
                column: "Id_ChiThiMau");

            migrationBuilder.CreateIndex(
                name: "IX_ChiThiPheDuyet_ChiTiets_Id_ChiThiPheDuyet",
                table: "ChiThiPheDuyet_ChiTiets",
                column: "Id_ChiThiPheDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_ChiThiPheDuyet_ChiTiets_PICCheckId",
                table: "ChiThiPheDuyet_ChiTiets",
                column: "PICCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiThiPheDuyets_PICCreate",
                table: "ChiThiPheDuyets",
                column: "PICCreate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiThi_Templates");

            migrationBuilder.DropTable(
                name: "ChiThiMau_ChiTiets");

            migrationBuilder.DropTable(
                name: "ChiThiPheDuyet_ChiTiets");

            migrationBuilder.DropTable(
                name: "ChiThiMaus");

            migrationBuilder.DropTable(
                name: "ChiThiPheDuyets");

            migrationBuilder.DropTable(
                name: "NguoiDungs");
        }
    }
}
