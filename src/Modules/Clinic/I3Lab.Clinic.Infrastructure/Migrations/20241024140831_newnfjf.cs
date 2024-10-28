using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Clinics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newnfjf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicDoctors_Doctor_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                schema: "clinic",
                table: "Doctor");

            migrationBuilder.RenameTable(
                name: "Doctor",
                schema: "clinic",
                newName: "Doctors",
                newSchema: "clinic");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicStatus",
                schema: "clinic",
                table: "Clinics",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicName",
                schema: "clinic",
                table: "Clinics",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicAddress",
                schema: "clinic",
                table: "Clinics",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationStatus",
                schema: "clinic",
                table: "ClinicCreationProposals",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicName",
                schema: "clinic",
                table: "ClinicCreationProposals",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicAddress",
                schema: "clinic",
                table: "ClinicCreationProposals",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "clinic",
                table: "Doctors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name_LastName",
                schema: "clinic",
                table: "Doctors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name_FirstName",
                schema: "clinic",
                table: "Doctors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "clinic",
                table: "Doctors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorAvatarUrl",
                schema: "clinic",
                table: "Doctors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                schema: "clinic",
                table: "Doctors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DoctorCreationProposals",
                schema: "clinic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name_FirstName = table.Column<string>(type: "text", nullable: true),
                    Name_LastName = table.Column<string>(type: "text", nullable: true),
                    Emailll = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ConfirmationStatuss = table.Column<string>(type: "text", nullable: true),
                    DoctorAvatarUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorCreationProposals", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicDoctors_Doctors_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors",
                column: "DoctorId",
                principalSchema: "clinic",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicDoctors_Doctors_DoctorId",
                schema: "clinic",
                table: "ClinicDoctors");

            migrationBuilder.DropTable(
                name: "DoctorCreationProposals",
                schema: "clinic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                schema: "clinic",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Doctors",
                schema: "clinic",
                newName: "Doctor",
                newSchema: "clinic");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicStatus",
                schema: "clinic",
                table: "Clinics",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClinicName",
                schema: "clinic",
                table: "Clinics",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClinicAddress",
                schema: "clinic",
                table: "Clinics",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationStatus",
                schema: "clinic",
                table: "ClinicCreationProposals",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClinicName",
                schema: "clinic",
                table: "ClinicCreationProposals",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClinicAddress",
                schema: "clinic",
                table: "ClinicCreationProposals",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "clinic",
                table: "Doctor",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_LastName",
                schema: "clinic",
                table: "Doctor",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_FirstName",
                schema: "clinic",
                table: "Doctor",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "clinic",
                table: "Doctor",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorAvatarUrl",
                schema: "clinic",
                table: "Doctor",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                schema: "clinic",
                table: "Doctor",
                column: "Id");

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
    }
}
