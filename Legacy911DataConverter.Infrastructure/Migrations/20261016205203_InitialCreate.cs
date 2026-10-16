using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Legacy911DataConverter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConversionBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalRecords = table.Column<int>(type: "int", nullable: false),
                    SuccessfulRecords = table.Column<int>(type: "int", nullable: false),
                    FailedRecords = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionBatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConversionErrors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    IncidentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Field = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionErrors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversionErrors_ConversionBatches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "ConversionBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CallType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OccurredAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "Unknown"),
                    Priority = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "Unspecified"),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_ConversionBatches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "ConversionBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RespondingUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Agency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespondingUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespondingUnits_ConversionBatches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "ConversionBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversionErrors_BatchId",
                table: "ConversionErrors",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_BatchId",
                table: "Incidents",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentNumber",
                table: "Incidents",
                column: "IncidentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RespondingUnits_BatchId",
                table: "RespondingUnits",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RespondingUnits_UnitCode",
                table: "RespondingUnits",
                column: "UnitCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionErrors");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "RespondingUnits");

            migrationBuilder.DropTable(
                name: "ConversionBatches");
        }
    }
}
