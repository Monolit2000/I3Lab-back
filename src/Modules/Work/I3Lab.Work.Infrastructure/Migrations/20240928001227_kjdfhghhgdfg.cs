using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class kjdfhghhgdfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStageFile_Works_WorkId",
                schema: "work",
                table: "TreatmentStageFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Members_CreatorId",
                schema: "work",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Members_CustomerId",
                schema: "work",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_TreatmentStageFile_TreatmentStageAvatarImageWorkId",
                schema: "work",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Works",
                schema: "work",
                table: "Works");

            migrationBuilder.EnsureSchema(
                name: "treatment");

            migrationBuilder.RenameTable(
                name: "WorkChatMessages",
                schema: "work",
                newName: "WorkChatMessages",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "TreatmentStageFile",
                schema: "work",
                newName: "TreatmentStageFile",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "TreatmentStageChats",
                schema: "work",
                newName: "TreatmentStageChats",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "Treatments",
                schema: "work",
                newName: "Treatments",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "TreatmentMembers",
                schema: "work",
                newName: "TreatmentMembers",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "TreatmentInvites",
                schema: "work",
                newName: "TreatmentInvites",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "Members",
                schema: "work",
                newName: "Members",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "InternalCommands",
                schema: "work",
                newName: "InternalCommands",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "ChatMembers",
                schema: "work",
                newName: "ChatMembers",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "BlobFiles",
                schema: "work",
                newName: "BlobFiles",
                newSchema: "treatment");

            migrationBuilder.RenameTable(
                name: "Works",
                schema: "work",
                newName: "TreatmentStage",
                newSchema: "treatment");

            migrationBuilder.RenameIndex(
                name: "IX_Works_TreatmentStageAvatarImageWorkId",
                schema: "treatment",
                table: "TreatmentStage",
                newName: "IX_TreatmentStage_TreatmentStageAvatarImageWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_CustomerId",
                schema: "treatment",
                table: "TreatmentStage",
                newName: "IX_TreatmentStage_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_CreatorId",
                schema: "treatment",
                table: "TreatmentStage",
                newName: "IX_TreatmentStage_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreatmentStage",
                schema: "treatment",
                table: "TreatmentStage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentStage_Members_CreatorId",
                schema: "treatment",
                table: "TreatmentStage",
                column: "CreatorId",
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
                principalColumn: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentStageFile_TreatmentStage_WorkId",
                schema: "treatment",
                table: "TreatmentStageFile",
                column: "WorkId",
                principalSchema: "treatment",
                principalTable: "TreatmentStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStage_Members_CreatorId",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStage_Members_CustomerId",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStage_TreatmentStageFile_TreatmentStageAvatarImage~",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStageFile_TreatmentStage_WorkId",
                schema: "treatment",
                table: "TreatmentStageFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreatmentStage",
                schema: "treatment",
                table: "TreatmentStage");

            migrationBuilder.EnsureSchema(
                name: "work");

            migrationBuilder.RenameTable(
                name: "WorkChatMessages",
                schema: "treatment",
                newName: "WorkChatMessages",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "TreatmentStageFile",
                schema: "treatment",
                newName: "TreatmentStageFile",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "TreatmentStageChats",
                schema: "treatment",
                newName: "TreatmentStageChats",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "Treatments",
                schema: "treatment",
                newName: "Treatments",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "TreatmentMembers",
                schema: "treatment",
                newName: "TreatmentMembers",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "TreatmentInvites",
                schema: "treatment",
                newName: "TreatmentInvites",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "Members",
                schema: "treatment",
                newName: "Members",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "InternalCommands",
                schema: "treatment",
                newName: "InternalCommands",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "ChatMembers",
                schema: "treatment",
                newName: "ChatMembers",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "BlobFiles",
                schema: "treatment",
                newName: "BlobFiles",
                newSchema: "work");

            migrationBuilder.RenameTable(
                name: "TreatmentStage",
                schema: "treatment",
                newName: "Works",
                newSchema: "work");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentStage_TreatmentStageAvatarImageWorkId",
                schema: "work",
                table: "Works",
                newName: "IX_Works_TreatmentStageAvatarImageWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentStage_CustomerId",
                schema: "work",
                table: "Works",
                newName: "IX_Works_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_TreatmentStage_CreatorId",
                schema: "work",
                table: "Works",
                newName: "IX_Works_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Works",
                schema: "work",
                table: "Works",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentStageFile_Works_WorkId",
                schema: "work",
                table: "TreatmentStageFile",
                column: "WorkId",
                principalSchema: "work",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Members_CreatorId",
                schema: "work",
                table: "Works",
                column: "CreatorId",
                principalSchema: "work",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Members_CustomerId",
                schema: "work",
                table: "Works",
                column: "CustomerId",
                principalSchema: "work",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_TreatmentStageFile_TreatmentStageAvatarImageWorkId",
                schema: "work",
                table: "Works",
                column: "TreatmentStageAvatarImageWorkId",
                principalSchema: "work",
                principalTable: "TreatmentStageFile",
                principalColumn: "WorkId");
        }
    }
}
