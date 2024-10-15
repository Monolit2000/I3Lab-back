using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Clinics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newmoiigfgfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicDoctors",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.DropIndex(
                name: "IX_ClinicDoctors_ClinicId",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                schema: "clinic",
                table: "ClinicDoctors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicDoctors",
                schema: "clinic",
                table: "ClinicDoctors",
                columns: new[] { "ClinicId", "DoctorId" });

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name_FirstName = table.Column<string>(type: "text", nullable: false),
                    Name_LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    DoctorAvatarUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctors_AddedAt",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "AddedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctors_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicDoctors_Doctor_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "DoctorId",
                principalSchema: "clinic",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicDoctors_Doctor_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "clinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicDoctors",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.DropIndex(
                name: "IX_ClinicDoctors_AddedAt",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.DropIndex(
                name: "IX_ClinicDoctors_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicDoctors",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctors_ClinicId",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "ClinicId");
        }
    }
}
