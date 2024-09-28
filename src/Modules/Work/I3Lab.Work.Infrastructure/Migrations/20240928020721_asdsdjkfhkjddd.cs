using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class asdsdjkfhkjddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TreatmentStatus",
                schema: "treatment",
                table: "Treatments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreatmentStatus",
                schema: "treatment",
                table: "Treatments");
        }
    }
}
