using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nsdfjhfdg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentMembers_Members_AddedById",
                schema: "treatment",
                table: "TreatmentMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStage_Members_CustomerId",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStage_TreatmentStageFile_TreatmentStageAvatarImage~",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentStage_CustomerId",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentStage_TreatmentStageAvatarImageWorkId",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentMembers_AddedById",
                schema: "treatment",
                table: "TreatmentMembers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropColumn(
                name: "TreatmentStageAvatarImageWorkId",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropColumn(
                name: "AddedById",
                schema: "treatment",
                table: "TreatmentMembers");

            migrationBuilder.AddColumn<Guid>(
                name: "TreatmentStageId1",
                schema: "treatment",
                table: "TreatmentStageFile",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStageFile_TreatmentStageId1",
                schema: "treatment",
                table: "TreatmentStageFile",
                column: "TreatmentStageId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentStageFile_TreatmentStage_TreatmentStageId1",
                schema: "treatment",
                table: "TreatmentStageFile",
                column: "TreatmentStageId1",
                principalSchema: "treatment",
                principalTable: "TreatmentStage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStageFile_TreatmentStage_TreatmentStageId1",
                schema: "treatment",
                table: "TreatmentStageFile");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentStageFile_TreatmentStageId1",
                schema: "treatment",
                table: "TreatmentStageFile");

            migrationBuilder.DropColumn(
                name: "TreatmentStageId1",
                schema: "treatment",
                table: "TreatmentStageFile");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "treatment",
                table: "TreatmentStage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TreatmentStageAvatarImageWorkId",
                schema: "treatment",
                table: "TreatmentStage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddedById",
                schema: "treatment",
                table: "TreatmentMembers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStage_CustomerId",
                schema: "treatment",
                table: "TreatmentStage",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStage_TreatmentStageAvatarImageWorkId",
                schema: "treatment",
                table: "TreatmentStage",
                column: "TreatmentStageAvatarImageWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_AddedById",
                schema: "treatment",
                table: "TreatmentMembers",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentMembers_Members_AddedById",
                schema: "treatment",
                table: "TreatmentMembers",
                column: "AddedById",
                principalSchema: "treatment",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentStage_Members_CustomerId",
                schema: "treatment",
                table: "TreatmentStage",
                column: "CustomerId",
                principalSchema: "treatment",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentStage_TreatmentStageFile_TreatmentStageAvatarImage~",
                schema: "treatment",
                table: "TreatmentStage",
                column: "TreatmentStageAvatarImageWorkId",
                principalSchema: "treatment",
                principalTable: "TreatmentStageFile",
                principalColumn: "TreatmentStageId");
        }
    }
}
