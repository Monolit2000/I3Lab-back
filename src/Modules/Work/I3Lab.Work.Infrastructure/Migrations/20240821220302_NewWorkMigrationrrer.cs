using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Works.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewWorkMigrationrrer : Migration
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
                    BlobFilePath = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlobFiles", x => x.Id);
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
                name: "Treatments",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TreatmentPreview = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                schema: "work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentName = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkStartedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "WorkFile",
                schema: "work",
                columns: table => new
                {
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContainerName = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFile", x => x.FileId);
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

            migrationBuilder.CreateTable(
                name: "WorkMember",
                schema: "work",
                columns: table => new
                {
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessibilityType = table.Column<string>(type: "text", nullable: true),
                    AddedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkMember", x => new { x.WorkId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_WorkMember_Works_WorkId",
                        column: x => x.WorkId,
                        principalSchema: "work",
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStage_TreatmentId",
                schema: "work",
                table: "TreatmentStage",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFile_WorkId",
                schema: "work",
                table: "WorkFile",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFile_WorkId1",
                schema: "work",
                table: "WorkFile",
                column: "WorkId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkMember_WorkId_MemberId",
                schema: "work",
                table: "WorkMember",
                columns: new[] { "WorkId", "MemberId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlobFiles",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "work");

            migrationBuilder.DropTable(
                name: "TreatmentStage",
                schema: "work");

            migrationBuilder.DropTable(
                name: "WorkFile",
                schema: "work");

            migrationBuilder.DropTable(
                name: "WorkMember",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Treatments",
                schema: "work");

            migrationBuilder.DropTable(
                name: "Works",
                schema: "work");
        }
    }
}
