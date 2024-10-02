using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Clinics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class asddsfdsf : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinics",
                schema: "clinic");
        }
    }
}
