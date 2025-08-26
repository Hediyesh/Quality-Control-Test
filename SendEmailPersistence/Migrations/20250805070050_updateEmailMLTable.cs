using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SendEmailPersistence.Migrations
{
    /// <inheritdoc />
    public partial class updateEmailMLTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "To",
                table: "EmailMessageMLs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "EmailMessageMLs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
