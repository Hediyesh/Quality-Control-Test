using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class EditTablesFeaturesRemoveParentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_NodeId_Type_ParentId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Features");

            migrationBuilder.CreateIndex(
                name: "IX_Features_NodeId_Type",
                table: "Features",
                columns: new[] { "NodeId", "Type" },
                unique: true,
                filter: "[NodeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_NodeId_Type",
                table: "Features");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Features",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_NodeId_Type_ParentId",
                table: "Features",
                columns: new[] { "NodeId", "Type", "ParentId" },
                unique: true,
                filter: "[NodeId] IS NOT NULL AND [ParentId] IS NOT NULL");
        }
    }
}
