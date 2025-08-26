using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batchs",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Defects",
                columns: table => new
                {
                    DefectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefectType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defects", x => x.DefectId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLogStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTypes",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTypes", x => x.MaintenanceId);
                });

            migrationBuilder.CreateTable(
                name: "MLTools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    ToolName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLTools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Severities",
                columns: table => new
                {
                    SeverityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeverityDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Severities", x => x.SeverityId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machines_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLogs",
                columns: table => new
                {
                    MLId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HoursSpent = table.Column<float>(type: "real", nullable: false),
                    NextScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceLogStatusId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MachineId1 = table.Column<int>(type: "int", nullable: true),
                    MaintenanceLogStatusStatusId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceTypeMaintenanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogs", x => x.MLId);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_Machines_MachineId1",
                        column: x => x.MachineId1,
                        principalTable: "Machines",
                        principalColumn: "MachineId");
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_MaintenanceLogStatuses_MaintenanceLogStatusId",
                        column: x => x.MaintenanceLogStatusId,
                        principalTable: "MaintenanceLogStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_MaintenanceLogStatuses_MaintenanceLogStatusStatusId",
                        column: x => x.MaintenanceLogStatusStatusId,
                        principalTable: "MaintenanceLogStatuses",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_MaintenanceTypes_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "MaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_MaintenanceTypes_MaintenanceTypeMaintenanceId",
                        column: x => x.MaintenanceTypeMaintenanceId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "MaintenanceId");
                });

            migrationBuilder.CreateTable(
                name: "MachineProduct",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineProduct", x => new { x.MachineId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_MachineProduct_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityControlEntries",
                columns: table => new
                {
                    QCEId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityInspected = table.Column<int>(type: "int", nullable: false),
                    QualityDefective = table.Column<int>(type: "int", nullable: false),
                    DefectDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RootCause = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CorrectiveAction = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    SeverityId = table.Column<int>(type: "int", nullable: false),
                    DefectId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BatchId1 = table.Column<int>(type: "int", nullable: true),
                    DefectId1 = table.Column<int>(type: "int", nullable: true),
                    MachineId1 = table.Column<int>(type: "int", nullable: true),
                    ProductId1 = table.Column<int>(type: "int", nullable: true),
                    SeverityId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlEntries", x => x.QCEId);
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batchs",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Batchs_BatchId1",
                        column: x => x.BatchId1,
                        principalTable: "Batchs",
                        principalColumn: "BatchId");
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "DefectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Defects_DefectId1",
                        column: x => x.DefectId1,
                        principalTable: "Defects",
                        principalColumn: "DefectId");
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Machines_MachineId1",
                        column: x => x.MachineId1,
                        principalTable: "Machines",
                        principalColumn: "MachineId");
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Severities_SeverityId",
                        column: x => x.SeverityId,
                        principalTable: "Severities",
                        principalColumn: "SeverityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlEntries_Severities_SeverityId1",
                        column: x => x.SeverityId1,
                        principalTable: "Severities",
                        principalColumn: "SeverityId");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLogTools",
                columns: table => new
                {
                    MLId = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogTools", x => new { x.MLId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_MaintenanceLogTools_MLTools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "MLTools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogTools_MaintenanceLogs_MLId",
                        column: x => x.MLId,
                        principalTable: "MaintenanceLogs",
                        principalColumn: "MLId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CompanyId",
                table: "Categories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineProduct_ProductId",
                table: "MachineProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_CompanyId",
                table: "Machines",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_CompanyId",
                table: "MaintenanceLogs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_MachineId",
                table: "MaintenanceLogs",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_MachineId1",
                table: "MaintenanceLogs",
                column: "MachineId1");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_MaintenanceId",
                table: "MaintenanceLogs",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_MaintenanceLogStatusId",
                table: "MaintenanceLogs",
                column: "MaintenanceLogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_MaintenanceLogStatusStatusId",
                table: "MaintenanceLogs",
                column: "MaintenanceLogStatusStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_MaintenanceTypeMaintenanceId",
                table: "MaintenanceLogs",
                column: "MaintenanceTypeMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogTools_ToolId",
                table: "MaintenanceLogTools",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_BatchId",
                table: "QualityControlEntries",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_BatchId1",
                table: "QualityControlEntries",
                column: "BatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_CompanyId",
                table: "QualityControlEntries",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_DefectId",
                table: "QualityControlEntries",
                column: "DefectId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_DefectId1",
                table: "QualityControlEntries",
                column: "DefectId1");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_MachineId",
                table: "QualityControlEntries",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_MachineId1",
                table: "QualityControlEntries",
                column: "MachineId1");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_ProductId",
                table: "QualityControlEntries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_ProductId1",
                table: "QualityControlEntries",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_SeverityId",
                table: "QualityControlEntries",
                column: "SeverityId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlEntries_SeverityId1",
                table: "QualityControlEntries",
                column: "SeverityId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineProduct");

            migrationBuilder.DropTable(
                name: "MaintenanceLogTools");

            migrationBuilder.DropTable(
                name: "QualityControlEntries");

            migrationBuilder.DropTable(
                name: "MLTools");

            migrationBuilder.DropTable(
                name: "MaintenanceLogs");

            migrationBuilder.DropTable(
                name: "Batchs");

            migrationBuilder.DropTable(
                name: "Defects");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Severities");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "MaintenanceLogStatuses");

            migrationBuilder.DropTable(
                name: "MaintenanceTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
