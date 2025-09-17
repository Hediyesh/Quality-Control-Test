using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPersistence.Migrations
{
    /// <inheritdoc />
    public partial class SetIndexNodeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Features_NodeId_Type",
                table: "Features",
                columns: new[] { "NodeId", "Type" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_NodeId_Type",
                table: "Features");
        }
    }
}
