using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUserMigrationRefrashTokenDeletedRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefrashToken",
                schema: "User",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenCreated",
                schema: "User",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenExpires",
                schema: "User",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefrashToken",
                schema: "User",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenCreated",
                schema: "User",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpires",
                schema: "User",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
