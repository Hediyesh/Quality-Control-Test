using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class EditTables : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Products_FeatureNodeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Machines_FeatureNodeId",
                table: "Machines");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Features_NodeId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_NodeId_Type",
                table: "Features");

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

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId1",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "Machines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId1",
                table: "Machines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NodeId",
                table: "Features",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId1",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId1",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FeatureId",
                table: "Products",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FeatureId1",
                table: "Products",
                column: "FeatureId1",
                unique: true,
                filter: "[FeatureId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_FeatureId",
                table: "Machines",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_FeatureId1",
                table: "Machines",
                column: "FeatureId1",
                unique: true,
                filter: "[FeatureId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Features_NodeId_Type",
                table: "Features",
                columns: new[] { "NodeId", "Type" },
                unique: true,
                filter: "[NodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FeatureId",
                table: "Companies",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FeatureId1",
                table: "Companies",
                column: "FeatureId1",
                unique: true,
                filter: "[FeatureId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FeatureId",
                table: "Categories",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FeatureId1",
                table: "Categories",
                column: "FeatureId1",
                unique: true,
                filter: "[FeatureId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Features_FeatureId",
                table: "Categories",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Features_FeatureId1",
                table: "Categories",
                column: "FeatureId1",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Features_FeatureId",
                table: "Companies",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Features_FeatureId1",
                table: "Companies",
                column: "FeatureId1",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Features_FeatureId",
                table: "Machines",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Features_FeatureId1",
                table: "Machines",
                column: "FeatureId1",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Features_FeatureId",
                table: "Products",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Features_FeatureId1",
                table: "Products",
                column: "FeatureId1",
                principalTable: "Features",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Features_FeatureId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Features_FeatureId1",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Features_FeatureId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Features_FeatureId1",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Features_FeatureId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Features_FeatureId1",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Features_FeatureId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Features_FeatureId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FeatureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FeatureId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Machines_FeatureId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_FeatureId1",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Features_NodeId_Type",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Companies_FeatureId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_FeatureId1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FeatureId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FeatureId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "Categories");

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

            migrationBuilder.AlterColumn<int>(
                name: "NodeId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Features_NodeId",
                table: "Features",
                column: "NodeId");

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
                name: "IX_Features_NodeId_Type",
                table: "Features",
                columns: new[] { "NodeId", "Type" },
                unique: true);

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
