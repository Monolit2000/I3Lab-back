using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Works.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationRemuveColumNameDefinitionTEST : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentStage",
                schema: "work");

            migrationBuilder.CreateIndex(
                name: "IX_Works_TreatmentId",
                schema: "work",
                table: "Works",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Treatments_TreatmentId",
                schema: "work",
                table: "Works",
                column: "TreatmentId",
                principalSchema: "work",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Treatments_TreatmentId",
                schema: "work",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_TreatmentId",
                schema: "work",
                table: "Works");

            migrationBuilder.CreateTable(
                name: "TreatmentStage",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentStage_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "work",
                        principalTable: "Treatments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStage_TreatmentId",
                schema: "work",
                table: "TreatmentStage",
                column: "TreatmentId");
        }
    }
}
