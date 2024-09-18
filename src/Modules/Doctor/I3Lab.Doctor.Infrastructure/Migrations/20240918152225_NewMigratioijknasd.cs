using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Doctors.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigratioijknasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "doctors",
                table: "DoctorCreationProposals",
                newName: "Emailll");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emailll",
                schema: "doctors",
                table: "DoctorCreationProposals",
                newName: "Email");
        }
    }
}
