using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EmailValidation.Migrations.DataContext2Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailsV2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email_Address = table.Column<string>(type: "text", nullable: true),
                    Domain = table.Column<string>(type: "text", nullable: true),
                    Valid_Syntax = table.Column<bool>(type: "boolean", nullable: false),
                    Disposable = table.Column<bool>(type: "boolean", nullable: false),
                    WebMail = table.Column<bool>(type: "boolean", nullable: false),
                    Deliverable = table.Column<bool>(type: "boolean", nullable: false),
                    Catch_All = table.Column<bool>(type: "boolean", nullable: false),
                    Gibberish = table.Column<bool>(type: "boolean", nullable: false),
                    Spam = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsV2", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailsV2");
        }
    }
}
