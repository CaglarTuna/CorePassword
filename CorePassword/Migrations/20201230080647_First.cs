using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorePassword.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebsitePassword",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsitePassword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebsitePasswordHistory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsitePasswordId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsitePasswordHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsitePasswordHistory_WebsitePassword_WebsitePasswordId",
                        column: x => x.WebsitePasswordId,
                        principalTable: "WebsitePassword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebsitePasswordHistory_WebsitePasswordId",
                table: "WebsitePasswordHistory",
                column: "WebsitePasswordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebsitePasswordHistory");

            migrationBuilder.DropTable(
                name: "WebsitePassword");
        }
    }
}
