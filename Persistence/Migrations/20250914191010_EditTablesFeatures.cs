using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class EditTablesFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FeatureId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FeatureId1",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FeatureId",
                table: "Products",
                column: "FeatureId",
                unique: true,
                filter: "[FeatureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_FeatureId",
                table: "Machines",
                column: "FeatureId",
                unique: true,
                filter: "[FeatureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FeatureId",
                table: "Companies",
                column: "FeatureId",
                unique: true,
                filter: "[FeatureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FeatureId",
                table: "Categories",
                column: "FeatureId",
                unique: true,
                filter: "[FeatureId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Features_FeatureId",
                table: "Categories",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Features_FeatureId",
                table: "Companies",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Features_FeatureId",
                table: "Machines",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Features_FeatureId",
                table: "Products",
                column: "FeatureId",
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
                name: "FK_Companies_Features_FeatureId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Features_FeatureId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Features_FeatureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FeatureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Machines_FeatureId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Companies_FeatureId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FeatureId",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId1",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId1",
                table: "Machines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId1",
                table: "Companies",
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
    }
}
