using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Doctors.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigratioijkn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "doctors");

            migrationBuilder.CreateTable(
                name: "DoctorCreationProposals",
                schema: "doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name_FirstName = table.Column<string>(type: "text", nullable: true),
                    Name_LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ConfirmationStatus = table.Column<string>(type: "text", nullable: true),
                    DoctorAvatarUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorCreationProposals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name_FirstName = table.Column<string>(type: "text", nullable: true),
                    Name_LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    DoctorAvatarUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorCreationProposals",
                schema: "doctors");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "doctors");
        }
    }
}
