using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedInviteTokenToTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvitationToken",
                schema: "work",
                table: "Treatments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InviteTokenExpiryDate",
                schema: "work",
                table: "Treatments",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvitationToken",
                schema: "work",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "InviteTokenExpiryDate",
                schema: "work",
                table: "Treatments");
        }
    }
}
