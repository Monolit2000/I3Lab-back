using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Doctors.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigratioijknasdasdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmationStatus",
                schema: "doctors",
                table: "DoctorCreationProposals",
                newName: "ConfirmationStatuss");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmationStatuss",
                schema: "doctors",
                table: "DoctorCreationProposals",
                newName: "ConfirmationStatus");
        }
    }
}
