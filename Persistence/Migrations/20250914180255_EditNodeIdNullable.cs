using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class EditNodeIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_NodeId",
                table: "Features");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Features_NodeId",
                table: "Features",
                column: "NodeId",
                unique: true);
        }
    }
}
