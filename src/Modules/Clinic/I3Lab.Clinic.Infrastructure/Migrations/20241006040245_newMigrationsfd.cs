using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Clinics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMigrationsfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "clinic");

            migrationBuilder.CreateTable(
                name: "Clinics",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClinicName = table.Column<string>(type: "text", nullable: false),
                    ClinicAddress = table.Column<string>(type: "text", nullable: false),
                    ClinicStatus = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicDoctors",
                schema: "clinic",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicDoctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_ClinicDoctors_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalSchema: "clinic",
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctors_ClinicId",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicDoctors",
                schema: "clinic");

            migrationBuilder.DropTable(
                name: "Clinics",
                schema: "clinic");
        }
    }
}
