using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Works.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TreatmentInv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "work");

            migrationBuilder.CreateTable(
                name: "BlobFiles",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileType = table.Column<string>(type: "text", nullable: true),
                    Accessibilitylevel = table.Column<string>(type: "text", nullable: true),
                    BlobName = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    BlobDirectoryName = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Path_ContainerName = table.Column<string>(type: "text", nullable: true),
                    Path_FileName = table.Column<string>(type: "text", nullable: true),
                    Path_BlobDirectoryName = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlobFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkChats",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkChats", x => x.Id);
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
                    WorkChatId = table.Column<Guid>(type: "uuid", nullable: true),
                    MemberRole = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_WorkChats_WorkChatId",
                        column: x => x.WorkChatId,
                        principalSchema: "work",
                        principalTable: "WorkChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    Titel = table.Column<string>(type: "text", nullable: true),
                    TreatmentPreviewId = table.Column<Guid>(type: "uuid", nullable: true),
                    TreatmentDate_TreatmentStarted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TreatmentDate_TreatmentFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_BlobFiles_TreatmentPreviewId",
                        column: x => x.TreatmentPreviewId,
                        principalSchema: "work",
                        principalTable: "BlobFiles",
                        principalColumn: "Id");
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
                name: "WorkChatMessages",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageText = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    SentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FileResponceIdId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsEdited = table.Column<bool>(type: "boolean", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                        name: "FK_WorkChatMessages_WorkChats_WorkChatId",
                        column: x => x.WorkChatId,
                        principalSchema: "work",
                        principalTable: "WorkChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentInvites",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberToInviteId = table.Column<Guid>(type: "uuid", nullable: false),
                    InviterId = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    MemberId = table.Column<Guid>(type: "uuid", nullable: true),
                    AccessibilityType = table.Column<string>(type: "text", nullable: true),
                    AddedById = table.Column<Guid>(type: "uuid", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Members_AddedById",
                        column: x => x.AddedById,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "work",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreatmentMembers_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "work",
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Titel = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkStartedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkStatus = table.Column<string>(type: "text", nullable: true)
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
                        name: "FK_Works_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalSchema: "work",
                        principalTable: "Treatments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkFile",
                schema: "work",
                columns: table => new
                {
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFile", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_WorkFile_BlobFiles_FileId",
                        column: x => x.FileId,
                        principalSchema: "work",
                        principalTable: "BlobFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkFile_Works_WorkId",
                        column: x => x.WorkId,
                        principalSchema: "work",
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkFile_Works_WorkId1",
                        column: x => x.WorkId1,
                        principalSchema: "work",
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_WorkChatId",
                schema: "work",
                table: "Members",
                column: "WorkChatId");

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
                column: "AddedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentMembers_MemberId",
                schema: "work",
                table: "TreatmentMembers",
                column: "MemberId",
                unique: true);

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
                name: "IX_Treatments_TreatmentPreviewId",
                schema: "work",
                table: "Treatments",
                column: "TreatmentPreviewId");

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
                name: "IX_WorkFile_FileId",
                schema: "work",
                table: "WorkFile",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFile_WorkId1",
                schema: "work",
                table: "WorkFile",
                column: "WorkId1",
                unique: true);

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
                name: "IX_Works_TreatmentId",
                schema: "work",
                table: "Works",
                column: "TreatmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "WorkFile",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Works",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Treatments",
                schema: "work");

            migrationBuilder.DropTable(
                name: "BlobFiles",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "work");

            migrationBuilder.DropTable(
                name: "WorkChats",
                schema: "work");
        }
    }
}
