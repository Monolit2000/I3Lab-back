using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class asdsdjkfhkj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentMembers_Members_AddedById",
                schema: "treatment",
                table: "TreatmentMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddedById",
                schema: "treatment",
                table: "TreatmentMembers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentMembers_Members_AddedById",
                schema: "treatment",
                table: "TreatmentMembers",
                column: "AddedById",
                principalSchema: "treatment",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentMembers_Members_AddedById",
                schema: "treatment",
                table: "TreatmentMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddedById",
                schema: "treatment",
                table: "TreatmentMembers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentMembers_Members_AddedById",
                schema: "treatment",
                table: "TreatmentMembers",
                column: "AddedById",
                principalSchema: "treatment",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
