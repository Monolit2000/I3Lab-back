using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Clinics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newmoiigfgfgdsafdsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicDoctors_Doctor_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicDoctors_Doctor_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "DoctorId",
                principalSchema: "clinic",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicDoctors_Doctor_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors");

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
    }
}
