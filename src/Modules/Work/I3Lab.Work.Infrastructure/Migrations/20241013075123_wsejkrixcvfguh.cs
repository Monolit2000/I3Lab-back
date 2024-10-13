using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class wsejkrixcvfguh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentFiles_Treatments_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentFiles_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles");

            migrationBuilder.AddColumn<Guid>(
                name: "TreatmentId1",
                schema: "treatment",
                table: "TreatmentFiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentFiles_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentFiles_TreatmentId1",
                schema: "treatment",
                table: "TreatmentFiles",
                column: "TreatmentId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentFiles_Treatments_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles",
                column: "TreatmentId",
                principalSchema: "treatment",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentFiles_Treatments_TreatmentId1",
                schema: "treatment",
                table: "TreatmentFiles",
                column: "TreatmentId1",
                principalSchema: "treatment",
                principalTable: "Treatments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentFiles_Treatments_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentFiles_Treatments_TreatmentId1",
                schema: "treatment",
                table: "TreatmentFiles");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentFiles_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentFiles_TreatmentId1",
                schema: "treatment",
                table: "TreatmentFiles");

            migrationBuilder.DropColumn(
                name: "TreatmentId1",
                schema: "treatment",
                table: "TreatmentFiles");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentFiles_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles",
                column: "TreatmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentFiles_Treatments_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles",
                column: "TreatmentId",
                principalSchema: "treatment",
                principalTable: "Treatments",
                principalColumn: "Id");
        }
    }
}
