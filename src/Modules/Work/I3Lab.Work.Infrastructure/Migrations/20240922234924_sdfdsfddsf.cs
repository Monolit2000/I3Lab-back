using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Works.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfdsfddsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "work");

            migrationBuilder.CreateTable(
                name: "InternalCommands",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    Error = table.Column<string>(type: "text", nullable: true),
                    EnqueueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProcessedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uuid", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    MemberRole = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentStageChats",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentStageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentStageChats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    TreatmentTitel = table.Column<string>(type: "text", nullable: true),
                    TreatmentDate_TreatmentStarted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentDate_TreatmentFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Members_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Treatments_Members_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatMembers",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentStageChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMembers_TreatmentStageChats_TreatmentStageChatId",
                        column: x => x.TreatmentStageChatId,
                        principalSchema: "work",
                        principalTable: "TreatmentStageChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlobFiles",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentStageId = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileType = table.Column<string>(type: "text", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    Accessibilitylevel = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Path_ContainerName = table.Column<string>(type: "text", nullable: true),
                    Path_FileName = table.Column<string>(type: "text", nullable: true),
                    Path_BlobDirectoryName = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlobFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlobFiles_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "work",
                        principalTable: "Treatments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentInvites",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberToInviteId = table.Column<Guid>(type: "uuid", nullable: false),
                    InviterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    OcurredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentInvites_Members_InviterId",
                        column: x => x.InviterId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentInvites_Members_MemberToInviteId",
                        column: x => x.MemberToInviteId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentInvites_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "work",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentMembers",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessibilityType = table.Column<string>(type: "text", nullable: true),
                    AddedById = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Members_AddedById",
                        column: x => x.AddedById,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "work",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkChatMessages",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileResponceIdId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageText = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsEdited = table.Column<bool>(type: "boolean", nullable: false),
                    SentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RepliedToMessageId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkChatMessages_BlobFiles_FileResponceIdId",
                        column: x => x.FileResponceIdId,
                        principalSchema: "work",
                        principalTable: "BlobFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkChatMessages_Members_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkChatMessages_TreatmentStageChats_WorkChatId",
                        column: x => x.WorkChatId,
                        principalSchema: "work",
                        principalTable: "TreatmentStageChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentStageFile",
                schema: "work",
                columns: table => new
                {
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentStageFile", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_TreatmentStageFile_BlobFiles_FileId",
                        column: x => x.FileId,
                        principalSchema: "work",
                        principalTable: "BlobFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Works",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    TreatmentTitel = table.Column<string>(type: "text", nullable: true),
                    TreatmentStageAvatarImageWorkId = table.Column<Guid>(type: "uuid", nullable: true),
                    TreatmentStageDate_StageStarted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentStageDate_StageFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentStageStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Members_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Works_Members_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Works_TreatmentStageFile_TreatmentStageAvatarImageWorkId",
                        column: x => x.TreatmentStageAvatarImageWorkId,
                        principalSchema: "work",
                        principalTable: "TreatmentStageFile",
                        principalColumn: "WorkId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlobFiles_TreatmentId",
                schema: "work",
                table: "BlobFiles",
                column: "TreatmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMembers_TreatmentStageChatId",
                schema: "work",
                table: "ChatMembers",
                column: "TreatmentStageChatId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentInvites_InviterId",
                schema: "work",
                table: "TreatmentInvites",
                column: "InviterId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentInvites_MemberToInviteId",
                schema: "work",
                table: "TreatmentInvites",
                column: "MemberToInviteId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentInvites_TreatmentId",
                schema: "work",
                table: "TreatmentInvites",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_AddedById",
                schema: "work",
                table: "TreatmentMembers",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_MemberId",
                schema: "work",
                table: "TreatmentMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_TreatmentId",
                schema: "work",
                table: "TreatmentMembers",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_CreatorId",
                schema: "work",
                table: "Treatments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PatientId",
                schema: "work",
                table: "Treatments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStageFile_FileId",
                schema: "work",
                table: "TreatmentStageFile",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkChatMessages_FileResponceIdId",
                schema: "work",
                table: "WorkChatMessages",
                column: "FileResponceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkChatMessages_SenderId",
                schema: "work",
                table: "WorkChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkChatMessages_WorkChatId",
                schema: "work",
                table: "WorkChatMessages",
                column: "WorkChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CreatorId",
                schema: "work",
                table: "Works",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CustomerId",
                schema: "work",
                table: "Works",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_TreatmentStageAvatarImageWorkId",
                schema: "work",
                table: "Works",
                column: "TreatmentStageAvatarImageWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentStageFile_Works_WorkId",
                schema: "work",
                table: "TreatmentStageFile",
                column: "WorkId",
                principalSchema: "work",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlobFiles_Treatments_TreatmentId",
                schema: "work",
                table: "BlobFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Members_CreatorId",
                schema: "work",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Members_CustomerId",
                schema: "work",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStageFile_BlobFiles_FileId",
                schema: "work",
                table: "TreatmentStageFile");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentStageFile_Works_WorkId",
                schema: "work",
                table: "TreatmentStageFile");

            migrationBuilder.DropTable(
                name: "ChatMembers",
                schema: "work");

            migrationBuilder.DropTable(
                name: "InternalCommands",
                schema: "work");

            migrationBuilder.DropTable(
                name: "TreatmentInvites",
                schema: "work");

            migrationBuilder.DropTable(
                name: "TreatmentMembers",
                schema: "work");

            migrationBuilder.DropTable(
                name: "WorkChatMessages",
                schema: "work");

            migrationBuilder.DropTable(
                name: "TreatmentStageChats",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Treatments",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "work");

            migrationBuilder.DropTable(
                name: "BlobFiles",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Works",
                schema: "work");

            migrationBuilder.DropTable(
                name: "TreatmentStageFile",
                schema: "work");
        }
    }
}
