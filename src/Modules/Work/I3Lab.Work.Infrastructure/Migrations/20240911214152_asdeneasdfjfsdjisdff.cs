using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Works.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class asdeneasdfjfsdjisdff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Treatments_TreatmentId1",
                schema: "work",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_TreatmentId1",
                schema: "work",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "TreatmentId1",
                schema: "work",
                table: "Works");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TreatmentId1",
                schema: "work",
                table: "Works",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_TreatmentId1",
                schema: "work",
                table: "Works",
                column: "TreatmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Treatments_TreatmentId1",
                schema: "work",
                table: "Works",
                column: "TreatmentId1",
                principalSchema: "work",
                principalTable: "Treatments",
                principalColumn: "Id");
        }
    }
}
