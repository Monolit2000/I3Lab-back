﻿// <auto-generated />
using System;
using System.Collections.Generic;
using I3Lab.Works.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace I3Lab.Works.Infrastructure.Migrations
{
    [DbContext(typeof(WorkContext))]
    [Migration("20240917194300_newPropertyCinfigureContentType")]
    partial class newPropertyCinfigureContentType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("work")
                .HasAnnotation("ProductVersion", "8.0.8")
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

                    b.ToTable("InternalCommands", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.BlobFiles.BlobFile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("BlobDirectoryName")
                        .HasColumnType("text");

                    b.Property<string>("BlobName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("BlobFiles", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Members.Member", b =>
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

                    b.ComplexProperty<Dictionary<string, object>>("MemberRole", "I3Lab.Works.Domain.Members.Member.MemberRole#MemberRole", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("MemberRole");
                        });

                    b.HasKey("Id");

                    b.ToTable("Members", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.TreatmentInvites.TreatmentInvite", b =>
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

                    b.ToTable("TreatmentInvites", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Treatments.Treatment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TreatmentPreviewId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("TreatmentPreviewId");

                    b.ToTable("Treatments", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.WorkChats.WorkChat", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("WorkChats", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Works.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TreatmentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("WorkStartedDate")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("WorkStatus", "I3Lab.Works.Domain.Works.Work.WorkStatus#WorkStatus", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("WorkStatus");
                        });

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Works", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Works.WorkFile", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("FileId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WorkId1")
                        .HasColumnType("uuid");

                    b.HasKey("WorkId");

                    b.HasIndex("FileId");

                    b.HasIndex("WorkId1")
                        .IsUnique();

                    b.ToTable("WorkFile", "work");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.BlobFiles.BlobFile", b =>
                {
                    b.OwnsOne("I3Lab.Works.Domain.BlobFiles.Accessibilitylevel", "Accessibilitylevel", b1 =>
                        {
                            b1.Property<Guid>("BlobFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Accessibilitylevel");

                            b1.HasKey("BlobFileId");

                            b1.ToTable("BlobFiles", "work");

                            b1.WithOwner()
                                .HasForeignKey("BlobFileId");
                        });

                    b.OwnsOne("I3Lab.Works.Domain.BlobFiles.BlobFilePath", "Path", b1 =>
                        {
                            b1.Property<Guid>("BlobFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("BlobDirectoryName")
                                .HasColumnType("text");

                            b1.Property<string>("ContainerName")
                                .HasColumnType("text");

                            b1.Property<string>("FileName")
                                .HasColumnType("text");

                            b1.HasKey("BlobFileId");

                            b1.ToTable("BlobFiles", "work");

                            b1.WithOwner()
                                .HasForeignKey("BlobFileId");
                        });

                    b.OwnsOne("I3Lab.Works.Domain.BlobFiles.BlobFileType", "FileType", b1 =>
                        {
                            b1.Property<Guid>("BlobFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("FileType");

                            b1.HasKey("BlobFileId");

                            b1.ToTable("BlobFiles", "work");

                            b1.WithOwner()
                                .HasForeignKey("BlobFileId");
                        });

                    b.OwnsOne("I3Lab.Works.Domain.BlobFiles.BlobFileUrl", "Url", b1 =>
                        {
                            b1.Property<Guid>("BlobFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Url");

                            b1.HasKey("BlobFileId");

                            b1.ToTable("BlobFiles", "work");

                            b1.WithOwner()
                                .HasForeignKey("BlobFileId");
                        });

                    b.OwnsOne("I3Lab.Works.Domain.BlobFiles.ContentType", "ContentType", b1 =>
                        {
                            b1.Property<Guid>("BlobFileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("ContentType");

                            b1.HasKey("BlobFileId");

                            b1.ToTable("BlobFiles", "work");

                            b1.WithOwner()
                                .HasForeignKey("BlobFileId");
                        });

                    b.Navigation("Accessibilitylevel");

                    b.Navigation("ContentType");

                    b.Navigation("FileType");

                    b.Navigation("Path");

                    b.Navigation("Url");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.TreatmentInvites.TreatmentInvite", b =>
                {
                    b.HasOne("I3Lab.Works.Domain.Members.Member", "Inviter")
                        .WithMany()
                        .HasForeignKey("InviterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("I3Lab.Works.Domain.Members.Member", "MemberToInvite")
                        .WithMany()
                        .HasForeignKey("MemberToInviteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("I3Lab.Works.Domain.Treatments.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("I3Lab.Works.Domain.TreatmentInvites.TreatmentInviteStatus", "TreatmentInviteStatus", b1 =>
                        {
                            b1.Property<Guid>("TreatmentInviteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Status");

                            b1.HasKey("TreatmentInviteId");

                            b1.ToTable("TreatmentInvites", "work");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentInviteId");
                        });

                    b.Navigation("Inviter");

                    b.Navigation("MemberToInvite");

                    b.Navigation("Treatment");

                    b.Navigation("TreatmentInviteStatus");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Treatments.Treatment", b =>
                {
                    b.HasOne("I3Lab.Works.Domain.Members.Member", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("I3Lab.Works.Domain.Members.Member", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("I3Lab.Works.Domain.BlobFiles.BlobFile", "TreatmentPreview")
                        .WithMany()
                        .HasForeignKey("TreatmentPreviewId");

                    b.OwnsOne("I3Lab.Works.Domain.Treatments.Titel", "Titel", b1 =>
                        {
                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Titel");

                            b1.HasKey("TreatmentId");

                            b1.ToTable("Treatments", "work");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");
                        });

                    b.OwnsOne("I3Lab.Works.Domain.Treatments.TreatmentDate", "TreatmentDate", b1 =>
                        {
                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("TreatmentFinished")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("TreatmentStarted")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("TreatmentId");

                            b1.ToTable("Treatments", "work");

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");
                        });

                    b.OwnsMany("I3Lab.Works.Domain.Treatments.TreatmentMember", "TreatmentMembers", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("AddedById")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("JoinDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("TreatmentId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("AddedById");

                            b1.HasIndex("MemberId");

                            b1.HasIndex("TreatmentId");

                            b1.ToTable("TreatmentMembers", "work");

                            b1.HasOne("I3Lab.Works.Domain.Members.Member", "AddedBy")
                                .WithMany()
                                .HasForeignKey("AddedById")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.HasOne("I3Lab.Works.Domain.Members.Member", "Member")
                                .WithMany()
                                .HasForeignKey("MemberId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("TreatmentId");

                            b1.OwnsOne("I3Lab.Works.Domain.Works.MemberAccessibilityType", "AccessibilityType", b2 =>
                                {
                                    b2.Property<Guid>("TreatmentMemberId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Value")
                                        .HasColumnType("text")
                                        .HasColumnName("AccessibilityType");

                                    b2.HasKey("TreatmentMemberId");

                                    b2.ToTable("TreatmentMembers", "work");

                                    b2.WithOwner()
                                        .HasForeignKey("TreatmentMemberId");
                                });

                            b1.Navigation("AccessibilityType");

                            b1.Navigation("AddedBy");

                            b1.Navigation("Member");
                        });

                    b.Navigation("Creator");

                    b.Navigation("Patient");

                    b.Navigation("Titel");

                    b.Navigation("TreatmentDate");

                    b.Navigation("TreatmentMembers");

                    b.Navigation("TreatmentPreview");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.WorkChats.WorkChat", b =>
                {
                    b.OwnsMany("I3Lab.Works.Domain.WorkChats.ChatMember", "ChatMembers", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("MemberId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("WorkChatId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("WorkChatId");

                            b1.ToTable("ChatMembers", "work");

                            b1.WithOwner()
                                .HasForeignKey("WorkChatId");
                        });

                    b.OwnsMany("I3Lab.Works.Domain.WorkChats.ChatMessage", "Messages", b1 =>
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

                            b1.ToTable("WorkChatMessages", "work");

                            b1.HasOne("I3Lab.Works.Domain.BlobFiles.BlobFile", "FileResponceId")
                                .WithMany()
                                .HasForeignKey("FileResponceIdId");

                            b1.HasOne("I3Lab.Works.Domain.Members.Member", null)
                                .WithMany()
                                .HasForeignKey("SenderId");

                            b1.WithOwner()
                                .HasForeignKey("WorkChatId");

                            b1.Navigation("FileResponceId");
                        });

                    b.Navigation("ChatMembers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Works.Work", b =>
                {
                    b.HasOne("I3Lab.Works.Domain.Members.Member", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("I3Lab.Works.Domain.Members.Member", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("I3Lab.Works.Domain.Treatments.Treatment", null)
                        .WithMany("TreatmentStages")
                        .HasForeignKey("TreatmentId");

                    b.OwnsOne("I3Lab.Works.Domain.Works.WorkTitel", "Titel", b1 =>
                        {
                            b1.Property<Guid>("WorkId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Titel");

                            b1.HasKey("WorkId");

                            b1.ToTable("Works", "work");

                            b1.WithOwner()
                                .HasForeignKey("WorkId");
                        });

                    b.Navigation("Creator");

                    b.Navigation("Customer");

                    b.Navigation("Titel");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Works.WorkFile", b =>
                {
                    b.HasOne("I3Lab.Works.Domain.BlobFiles.BlobFile", "File")
                        .WithMany()
                        .HasForeignKey("FileId");

                    b.HasOne("I3Lab.Works.Domain.Works.Work", null)
                        .WithMany("WorkFiles")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("I3Lab.Works.Domain.Works.Work", null)
                        .WithOne("WorkAvatarImage")
                        .HasForeignKey("I3Lab.Works.Domain.Works.WorkFile", "WorkId1");

                    b.Navigation("File");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Treatments.Treatment", b =>
                {
                    b.Navigation("TreatmentStages");
                });

            modelBuilder.Entity("I3Lab.Works.Domain.Works.Work", b =>
                {
                    b.Navigation("WorkAvatarImage");

                    b.Navigation("WorkFiles");
                });
#pragma warning restore 612, 618
        }
    }
}