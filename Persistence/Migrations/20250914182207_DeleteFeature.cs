using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Features_FeatureNodeId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Features_FeatureNodeId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Features_FeatureNodeId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Features_FeatureNodeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Products_FeatureNodeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Machines_FeatureNodeId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Companies_FeatureNodeId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FeatureNodeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FeatureNodeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FeatureNodeId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "FeatureNodeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FeatureNodeId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureNodeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureNodeId",
                table: "Machines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureNodeId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureNodeId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Node = table.Column<byte[]>(type: "hierarchyid", nullable: false),
                    NodeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.UniqueConstraint("AK_Features_NodeId", x => x.NodeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FeatureNodeId",
                table: "Products",
                column: "FeatureNodeId",
                unique: true,
                filter: "[FeatureNodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_FeatureNodeId",
                table: "Machines",
                column: "FeatureNodeId",
                unique: true,
                filter: "[FeatureNodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FeatureNodeId",
                table: "Companies",
                column: "FeatureNodeId",
                unique: true,
                filter: "[FeatureNodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FeatureNodeId",
                table: "Categories",
                column: "FeatureNodeId",
                unique: true,
                filter: "[FeatureNodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Features_NodeId",
                table: "Features",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Features_FeatureNodeId",
                table: "Categories",
                column: "FeatureNodeId",
                principalTable: "Features",
                principalColumn: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Features_FeatureNodeId",
                table: "Companies",
                column: "FeatureNodeId",
                principalTable: "Features",
                principalColumn: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Features_FeatureNodeId",
                table: "Machines",
                column: "FeatureNodeId",
                principalTable: "Features",
                principalColumn: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Features_FeatureNodeId",
                table: "Products",
                column: "FeatureNodeId",
                principalTable: "Features",
                principalColumn: "NodeId");
        }
    }
}
