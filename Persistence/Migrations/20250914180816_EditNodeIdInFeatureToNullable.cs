using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class EditNodeIdInFeatureToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Features_NodeId",
                table: "Features",
                column: "NodeId",
                unique: true,
                filter: "[NodeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_NodeId",
                table: "Features");
        }
    }
}
