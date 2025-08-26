using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SendEmailPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailForMaintenanceLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MLId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailForMaintenanceLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserForEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForEmails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailMessageLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessageLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailMessageLogins_UserForEmails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserForEmails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailMessageMLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSentId = table.Column<int>(type: "int", nullable: false),
                    emailMLId = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessageMLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailMessageMLs_EmailForMaintenanceLogs_emailMLId",
                        column: x => x.emailMLId,
                        principalTable: "EmailForMaintenanceLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailMessageMLs_UserForEmails_UserSentId",
                        column: x => x.UserSentId,
                        principalTable: "UserForEmails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessageLogins_UserId",
                table: "EmailMessageLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessageMLs_emailMLId",
                table: "EmailMessageMLs",
                column: "emailMLId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessageMLs_UserSentId",
                table: "EmailMessageMLs",
                column: "UserSentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailMessageLogins");

            migrationBuilder.DropTable(
                name: "EmailMessageMLs");

            migrationBuilder.DropTable(
                name: "EmailForMaintenanceLogs");

            migrationBuilder.DropTable(
                name: "UserForEmails");
        }
    }
}
