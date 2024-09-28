using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class asdsdjkfhkjdddsdds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                schema: "treatment",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                schema: "treatment",
                table: "Treatments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                schema: "treatment",
                table: "Treatments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                schema: "treatment",
                table: "Treatments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
