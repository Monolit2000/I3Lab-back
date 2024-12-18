﻿using System;
using System.Collections.Generic;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace I3Lab.Treatments.Infrastructure.Migrations
{
    [DbContext(typeof(TreatmentContext))]
    partial class TreatmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("treatment")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("I3Lab.BuildingBlocks.Infrastructure.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EnqueueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Error")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InternalCommands", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.Members.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentFiles.TreatmentFile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("MbSize")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("TreatmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TreatmentId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TreatmentStageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.HasIndex("TreatmentId1")
                        .IsUnique();

                    b.ToTable("TreatmentFiles", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentInvites.TreatmentInvite", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InviterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MemberToInviteId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("OcurredOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TreatmentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("InviterId");

                    b.HasIndex("MemberToInviteId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("TreatmentInvites", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentStageChats.TreatmentStageChat", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TreatmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TreatmentStageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TreatmentStageChats", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TreatmentId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("TreatmentStageStatus", "I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage.TreatmentStageStatus#TreatmentStageStatus", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("TreatmentStageStatus");
                        });

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("TreatmentStage", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStageFile", b =>
                {
                    b.Property<Guid>("TreatmentStageId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("FileId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TreatmentStageId1")
                        .HasColumnType("uuid");

                    b.HasKey("TreatmentStageId");

                    b.HasIndex("FileId");

                    b.HasIndex("TreatmentStageId1")
                        .IsUnique();

                    b.ToTable("TreatmentStageFile", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.Treatments.Treatment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Treatments", "treatment");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentFiles.TreatmentFile", b =>
                {
                    b.HasOne("I3Lab.Treatments.Domain.Treatments.Treatment", null)
                        .WithMany()
                        .HasForeignKey("TreatmentId");

                    b.HasOne("I3Lab.Treatments.Domain.Treatments.Treatment", null)
                        .WithOne("TreatmentPreview")
                        .HasForeignKey("I3Lab.Treatments.Domain.TreatmentFiles.TreatmentFile", "TreatmentId1");

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentFiles.BlobFilePath", "BlobFilePath", b1 =>
                        {
                            b1.Property<Guid>("TreatmentFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("BlobDirectoryName")
                                .HasColumnType("text");

                            b1.Property<string>("ContainerName")
                                .HasColumnType("text");

                            b1.Property<string>("FileName")
                                .HasColumnType("text");

                            b1.HasKey("TreatmentFileId");

                            b1.ToTable("TreatmentFiles", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentFileId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentFiles.BlobFileType", "FileType", b1 =>
                        {
                            b1.Property<Guid>("TreatmentFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("FileType");

                            b1.HasKey("TreatmentFileId");

                            b1.ToTable("TreatmentFiles", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentFileId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentFiles.BlobFileUrl", "Url", b1 =>
                        {
                            b1.Property<Guid>("TreatmentFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Url");

                            b1.HasKey("TreatmentFileId");

                            b1.ToTable("TreatmentFiles", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentFileId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentFiles.ContentType", "ContentType", b1 =>
                        {
                            b1.Property<Guid>("TreatmentFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("ContentType");

                            b1.HasKey("TreatmentFileId");

                            b1.ToTable("TreatmentFiles", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentFileId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentFiles.FilePreview", "FilePreview", b1 =>
                        {
                            b1.Property<Guid>("TreatmentFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Url")
                                .HasColumnType("text")
                                .HasColumnName("PreviewUrl");

                            b1.HasKey("TreatmentFileId");

                            b1.ToTable("TreatmentFiles", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentFileId");
                        });

                    b.Navigation("BlobFilePath");

                    b.Navigation("ContentType");

                    b.Navigation("FilePreview");

                    b.Navigation("FileType");

                    b.Navigation("Url");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentInvites.TreatmentInvite", b =>
                {
                    b.HasOne("I3Lab.Treatments.Domain.Members.Member", "InviterMember")
                        .WithMany()
                        .HasForeignKey("InviterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("I3Lab.Treatments.Domain.Members.Member", "InvitedMember")
                        .WithMany()
                        .HasForeignKey("MemberToInviteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("I3Lab.Treatments.Domain.Treatments.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentInvites.InviteToken", "InviteToken", b1 =>
                        {
                            b1.Property<Guid>("TreatmentInviteId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("ExpiryDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("InviteTokenExpiryDate");

                            b1.Property<string>("Token")
                                .HasColumnType("text")
                                .HasColumnName("InvitationToken");

                            b1.HasKey("TreatmentInviteId");

                            b1.ToTable("TreatmentInvites", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentInviteId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentInvites.TreatmentInviteStatus", "TreatmentInviteStatus", b1 =>
                        {
                            b1.Property<Guid>("TreatmentInviteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Status");

                            b1.HasKey("TreatmentInviteId");

                            b1.ToTable("TreatmentInvites", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentInviteId");
                        });

                    b.Navigation("InviteToken");

                    b.Navigation("InvitedMember");

                    b.Navigation("InviterMember");

                    b.Navigation("Treatment");

                    b.Navigation("TreatmentInviteStatus");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentStageChats.TreatmentStageChat", b =>
                {
                    b.OwnsMany("I3Lab.Treatments.Domain.TreatmentStageChats.ChatMember", "ChatMembers", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("TreatmentStageChatId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("TreatmentStageChatId");

                            b1.ToTable("ChatMembers", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentStageChatId");
                        });

                    b.OwnsMany("I3Lab.Treatments.Domain.TreatmentStageChats.Message", "Messages", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<DateTime?>("EditDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid?>("FileResponceIdId")
                                .HasColumnType("uuid");

                            b1.Property<bool>("IsEdited")
                                .HasColumnType("boolean");

                            b1.Property<string>("MessageText")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("character varying(1000)");

                            b1.Property<Guid?>("RepliedToMessageId")
                                .HasColumnType("uuid");

                            b1.Property<Guid?>("SenderId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("SentDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("WorkChatId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("FileResponceIdId");

                            b1.HasIndex("SenderId");

                            b1.HasIndex("WorkChatId");

                            b1.ToTable("WorkChatMessages", "treatment");

                            b1.HasOne("I3Lab.Treatments.Domain.TreatmentFiles.TreatmentFile", "FileResponceId")
                                .WithMany()
                                .HasForeignKey("FileResponceIdId");

                            b1.HasOne("I3Lab.Treatments.Domain.Members.Member", null)
                                .WithMany()
                                .HasForeignKey("SenderId");

                            b1.WithOwner()
                                .HasForeignKey("WorkChatId");

                            b1.Navigation("FileResponceId");
                        });

                    b.Navigation("ChatMembers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage", b =>
                {
                    b.HasOne("I3Lab.Treatments.Domain.Members.Member", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStageDate", "TreatmentStageDate", b1 =>
                        {
                            b1.Property<Guid>("TreatmentStageId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("StageFinished")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("StageStarted")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("TreatmentStageId");

                            b1.ToTable("TreatmentStage", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentStageId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStageTitel", "Titel", b1 =>
                        {
                            b1.Property<Guid>("TreatmentStageId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TreatmentTitel");

                            b1.HasKey("TreatmentStageId");

                            b1.ToTable("TreatmentStage", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentStageId");
                        });

                    b.Navigation("Creator");

                    b.Navigation("Titel");

                    b.Navigation("TreatmentStageDate");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStageFile", b =>
                {
                    b.HasOne("I3Lab.Treatments.Domain.TreatmentFiles.TreatmentFile", "File")
                        .WithMany()
                        .HasForeignKey("FileId");

                    b.HasOne("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage", null)
                        .WithMany("TreatmentStageFiles")
                        .HasForeignKey("TreatmentStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage", null)
                        .WithOne("TreatmentStageAvatarImage")
                        .HasForeignKey("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStageFile", "TreatmentStageId1");

                    b.Navigation("File");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.Treatments.Treatment", b =>
                {
                    b.HasOne("I3Lab.Treatments.Domain.Members.Member", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("I3Lab.Treatments.Domain.Members.Member", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.OwnsOne("I3Lab.Treatments.Domain.Treatments.InvitationToken", "InvitationToken", b1 =>
                        {
                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("ExpiryDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("InviteTokenExpiryDate");

                            b1.Property<string>("Token")
                                .HasColumnType("text")
                                .HasColumnName("InvitationToken");

                            b1.HasKey("TreatmentId");

                            b1.ToTable("Treatments", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.Treatments.TreatmentDate", "TreatmentDate", b1 =>
                        {
                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("TreatmentFinished")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("TreatmentStarted")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("TreatmentId");

                            b1.ToTable("Treatments", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");
                        });

                    b.OwnsMany("I3Lab.Treatments.Domain.Treatments.TreatmentMember", "TreatmentMembers", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("JoinDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("LeaveDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("MemberId");

                            b1.HasIndex("TreatmentId");

                            b1.ToTable("TreatmentMembers", "treatment");

                            b1.HasOne("I3Lab.Treatments.Domain.Members.Member", "Member")
                                .WithMany()
                                .HasForeignKey("MemberId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");

                            b1.OwnsOne("I3Lab.Treatments.Domain.TreatmentStages.TreatmentMemberAccessibilityType", "AccessibilityType", b2 =>
                                {
                                    b2.Property<Guid>("TreatmentMemberId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .HasColumnType("text")
                                        .HasColumnName("AccessibilityType");

                                    b2.HasKey("TreatmentMemberId");

                                    b2.ToTable("TreatmentMembers", "treatment");

                                    b2.WithOwner()
                                        .HasForeignKey("TreatmentMemberId");
                                });

                            b1.OwnsOne("I3Lab.Treatments.Domain.Treatments.TreatmentMemberRole", "Role", b2 =>
                                {
                                    b2.Property<Guid>("TreatmentMemberId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .HasColumnType("text")
                                        .HasColumnName("Role");

                                    b2.HasKey("TreatmentMemberId");

                                    b2.ToTable("TreatmentMembers", "treatment");

                                    b2.WithOwner()
                                        .HasForeignKey("TreatmentMemberId");
                                });

                            b1.Navigation("AccessibilityType");

                            b1.Navigation("Member");

                            b1.Navigation("Role");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.Treatments.TreatmentStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TreatmentStatus");

                            b1.HasKey("TreatmentId");

                            b1.ToTable("Treatments", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");
                        });

                    b.OwnsOne("I3Lab.Treatments.Domain.Treatments.TreatmentTitel", "Titel", b1 =>
                        {
                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TreatmentTitel");

                            b1.HasKey("TreatmentId");

                            b1.ToTable("Treatments", "treatment");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");
                        });

                    b.Navigation("Creator");

                    b.Navigation("InvitationToken");

                    b.Navigation("Patient");

                    b.Navigation("Status");

                    b.Navigation("Titel");

                    b.Navigation("TreatmentDate");

                    b.Navigation("TreatmentMembers");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.TreatmentStages.TreatmentStage", b =>
                {
                    b.Navigation("TreatmentStageAvatarImage");

                    b.Navigation("TreatmentStageFiles");
                });

            modelBuilder.Entity("I3Lab.Treatments.Domain.Treatments.Treatment", b =>
                {
                    b.Navigation("TreatmentPreview");
                });
#pragma warning restore 612, 618
        }
    }
}
