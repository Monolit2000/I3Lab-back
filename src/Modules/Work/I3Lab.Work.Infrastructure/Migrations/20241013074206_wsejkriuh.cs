using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class wsejkriuh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "treatment");

            migrationBuilder.CreateTable(
                name: "InternalCommands",
                schema: "treatment",
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
                schema: "treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uuid", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentStageChats",
                schema: "treatment",
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
                schema: "treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    TreatmentTitel = table.Column<string>(type: "text", nullable: true),
                    TreatmentDate_TreatmentStarted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentDate_TreatmentFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentStatus = table.Column<string>(type: "text", nullable: true),
                    InvitationToken = table.Column<string>(type: "text", nullable: true),
                    InviteTokenExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Members_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "treatment",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Treatments_Members_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "treatment",
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentStage",
                schema: "treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    TreatmentTitel = table.Column<string>(type: "text", nullable: true),
                    TreatmentStageDate_StageStarted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentStageDate_StageFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentStageStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentStage_Members_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "treatment",
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatMembers",
                schema: "treatment",
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
                        principalSchema: "treatment",
                        principalTable: "TreatmentStageChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentFiles",
                schema: "treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    TreatmentStageId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlobFilePath_ContainerName = table.Column<string>(type: "text", nullable: true),
                    BlobFilePath_FileName = table.Column<string>(type: "text", nullable: true),
                    BlobFilePath_BlobDirectoryName = table.Column<string>(type: "text", nullable: true),
                    PreviewUrl = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<string>(type: "text", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    MbSize = table.Column<double>(type: "double precision", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentFiles_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "treatment",
                        principalTable: "Treatments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentInvites",
                schema: "treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberToInviteId = table.Column<Guid>(type: "uuid", nullable: false),
                    InviterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    InvitationToken = table.Column<string>(type: "text", nullable: true),
                    InviteTokenExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OcurredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentInvites_Members_InviterId",
                        column: x => x.InviterId,
                        principalSchema: "treatment",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentInvites_Members_MemberToInviteId",
                        column: x => x.MemberToInviteId,
                        principalSchema: "treatment",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentInvites_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "treatment",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentMembers",
                schema: "treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    AccessibilityType = table.Column<string>(type: "text", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "treatment",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "treatment",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentStageFile",
                schema: "treatment",
                columns: table => new
                {
                    TreatmentStageId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TreatmentStageId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentStageFile", x => x.TreatmentStageId);
                    table.ForeignKey(
                        name: "FK_TreatmentStageFile_TreatmentFiles_FileId",
                        column: x => x.FileId,
                        principalSchema: "treatment",
                        principalTable: "TreatmentFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreatmentStageFile_TreatmentStage_TreatmentStageId",
                        column: x => x.TreatmentStageId,
                        principalSchema: "treatment",
                        principalTable: "TreatmentStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentStageFile_TreatmentStage_TreatmentStageId1",
                        column: x => x.TreatmentStageId1,
                        principalSchema: "treatment",
                        principalTable: "TreatmentStage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkChatMessages",
                schema: "treatment",
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
                        name: "FK_WorkChatMessages_Members_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "treatment",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkChatMessages_TreatmentFiles_FileResponceIdId",
                        column: x => x.FileResponceIdId,
                        principalSchema: "treatment",
                        principalTable: "TreatmentFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkChatMessages_TreatmentStageChats_WorkChatId",
                        column: x => x.WorkChatId,
                        principalSchema: "treatment",
                        principalTable: "TreatmentStageChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMembers_TreatmentStageChatId",
                schema: "treatment",
                table: "ChatMembers",
                column: "TreatmentStageChatId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentFiles_TreatmentId",
                schema: "treatment",
                table: "TreatmentFiles",
                column: "TreatmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentInvites_InviterId",
                schema: "treatment",
                table: "TreatmentInvites",
                column: "InviterId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentInvites_MemberToInviteId",
                schema: "treatment",
                table: "TreatmentInvites",
                column: "MemberToInviteId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentInvites_TreatmentId",
                schema: "treatment",
                table: "TreatmentInvites",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_MemberId",
                schema: "treatment",
                table: "TreatmentMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_TreatmentId",
                schema: "treatment",
                table: "TreatmentMembers",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_CreatorId",
                schema: "treatment",
                table: "Treatments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PatientId",
                schema: "treatment",
                table: "Treatments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStage_CreatorId",
                schema: "treatment",
                table: "TreatmentStage",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStageFile_FileId",
                schema: "treatment",
                table: "TreatmentStageFile",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStageFile_TreatmentStageId1",
                schema: "treatment",
                table: "TreatmentStageFile",
                column: "TreatmentStageId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkChatMessages_FileResponceIdId",
                schema: "treatment",
                table: "WorkChatMessages",
                column: "FileResponceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkChatMessages_SenderId",
                schema: "treatment",
                table: "WorkChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkChatMessages_WorkChatId",
                schema: "treatment",
                table: "WorkChatMessages",
                column: "WorkChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMembers",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "InternalCommands",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "TreatmentInvites",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "TreatmentMembers",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "TreatmentStageFile",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "WorkChatMessages",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "TreatmentStage",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "TreatmentFiles",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "TreatmentStageChats",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "Treatments",
                schema: "treatment");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "treatment");
        }
    }
}
