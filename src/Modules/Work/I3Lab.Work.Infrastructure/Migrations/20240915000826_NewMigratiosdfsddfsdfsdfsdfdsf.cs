using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Works.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigratiosdfsddfsdfsdfsdfdsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentMembers_Members_MemberId",
                schema: "work",
                table: "TreatmentMembers");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentMembers_MemberId",
                schema: "work",
                table: "TreatmentMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                schema: "work",
                table: "TreatmentMembers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_MemberId",
                schema: "work",
                table: "TreatmentMembers",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentMembers_Members_MemberId",
                schema: "work",
                table: "TreatmentMembers",
                column: "MemberId",
                principalSchema: "work",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentMembers_Members_MemberId",
                schema: "work",
                table: "TreatmentMembers");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentMembers_MemberId",
                schema: "work",
                table: "TreatmentMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberId",
                schema: "work",
                table: "TreatmentMembers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_MemberId",
                schema: "work",
                table: "TreatmentMembers",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentMembers_Members_MemberId",
                schema: "work",
                table: "TreatmentMembers",
                column: "MemberId",
                principalSchema: "work",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
