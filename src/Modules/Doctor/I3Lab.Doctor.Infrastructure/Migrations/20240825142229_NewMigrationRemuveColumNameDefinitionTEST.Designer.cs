﻿// <auto-generated />
using System;
using I3Lab.Doctors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace I3Lab.Doctors.Infrastructure.Migrations
{
    [DbContext(typeof(DoctorContext))]
    [Migration("20240825142229_NewMigrationRemuveColumNameDefinitionTEST")]
    partial class NewMigrationRemuveColumNameDefinitionTEST
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("doctors")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("I3Lab.Doctors.Domain.DoctorCreationProposals.DoctorCreationProposal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ConfirmationStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DoctorCreationProposals", "doctors");
                });

            modelBuilder.Entity("I3Lab.Doctors.Domain.Doctors.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Doctors", "doctors");
                });

            modelBuilder.Entity("I3Lab.Doctors.Domain.DoctorCreationProposals.DoctorCreationProposal", b =>
                {
                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.DoctorAvatar", "DoctorAvatar", b1 =>
                        {
                            b1.Property<Guid>("DoctorCreationProposalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("DoctorAvatarUrl");

                            b1.HasKey("DoctorCreationProposalId");

                            b1.ToTable("DoctorCreationProposals", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorCreationProposalId");
                        });

                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("DoctorCreationProposalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.HasKey("DoctorCreationProposalId");

                            b1.ToTable("DoctorCreationProposals", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorCreationProposalId");
                        });

                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.DoctorName", "Name", b1 =>
                        {
                            b1.Property<Guid>("DoctorCreationProposalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("DoctorCreationProposalId");

                            b1.ToTable("DoctorCreationProposals", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorCreationProposalId");
                        });

                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("DoctorCreationProposalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("DoctorCreationProposalId");

                            b1.ToTable("DoctorCreationProposals", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorCreationProposalId");
                        });

                    b.Navigation("DoctorAvatar")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("I3Lab.Doctors.Domain.Doctors.Doctor", b =>
                {
                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.DoctorAvatar", "DoctorAvatar", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("DoctorAvatarUrl");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.DoctorName", "Name", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("I3Lab.Doctors.Domain.Doctors.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors", "doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.Navigation("DoctorAvatar")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}