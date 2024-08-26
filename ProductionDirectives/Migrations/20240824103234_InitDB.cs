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
                    TotalStep = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    isDandory_Done = table.Column<bool>(type: "boolean", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PICCreate = table.Column<Guid>(type: "uuid", nullable: true),
                    Shift = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiThiMaus", x => x.Id);
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
                    Id_ChiThiPheDuyet = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiThiPheDuyet_ChiTiets", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_ChiThiMau_ChiTiets_Id_ChiThiMau",
                table: "ChiThiMau_ChiTiets",
                column: "Id_ChiThiMau");
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
        }
    }
}
