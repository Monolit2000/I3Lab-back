﻿// <auto-generated />
using System;
using I3Lab.Clinics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace I3Lab.Clinics.Infrastructure.Migrations
{
    [DbContext(typeof(ClinicContext))]
    [Migration("20241015185806_newmoiigfgfgdsafdsf")]
    partial class newmoiigfgfgdsafdsf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("clinic")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("I3Lab.Clinics.Domain.Clinics.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.HasKey("Id");

                    b.ToTable("Clinics", "clinic");
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Clinics.ClinicCreationProposal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.HasKey("Id");

                    b.ToTable("ClinicCreationProposals", "clinic");
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Clinics.ClinicDoctor", b =>
                {
                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ClinicId", "DoctorId");

                    b.HasIndex("AddedAt");

                    b.HasIndex("DoctorId");

                    b.ToTable("ClinicDoctors", "clinic");
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Doctors.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Doctor", "clinic");
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Clinics.Clinic", b =>
                {
                    b.OwnsOne("I3Lab.Clinics.Domain.Clinics.ClinicAddress", "Address", b1 =>
                        {
                            b1.Property<Guid>("ClinicId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ClinicAddress");

                            b1.HasKey("ClinicId");

                            b1.ToTable("Clinics", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("ClinicId");
                        });

                    b.OwnsOne("I3Lab.Clinics.Domain.Clinics.ClinicName", "ClinicName", b1 =>
                        {
                            b1.Property<Guid>("ClinicId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ClinicName");

                            b1.HasKey("ClinicId");

                            b1.ToTable("Clinics", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("ClinicId");
                        });

                    b.OwnsOne("I3Lab.Clinics.Domain.Clinics.ClinicStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("ClinicId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ClinicStatus");

                            b1.HasKey("ClinicId");

                            b1.ToTable("Clinics", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("ClinicId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("ClinicName")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Clinics.ClinicCreationProposal", b =>
                {
                    b.OwnsOne("I3Lab.Clinics.Domain.ClinicCreationProposals.ConfirmationStatus", "ConfirmationStatus", b1 =>
                        {
                            b1.Property<Guid>("ClinicCreationProposalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ConfirmationStatus");

                            b1.HasKey("ClinicCreationProposalId");

                            b1.ToTable("ClinicCreationProposals", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("ClinicCreationProposalId");
                        });

                    b.OwnsOne("I3Lab.Clinics.Domain.Clinics.ClinicAddress", "Address", b1 =>
                        {
                            b1.Property<Guid>("ClinicCreationProposalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ClinicAddress");

                            b1.HasKey("ClinicCreationProposalId");

                            b1.ToTable("ClinicCreationProposals", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("ClinicCreationProposalId");
                        });

                    b.OwnsOne("I3Lab.Clinics.Domain.Clinics.ClinicName", "ClinicName", b1 =>
                        {
                            b1.Property<Guid>("ClinicCreationProposalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ClinicName");

                            b1.HasKey("ClinicCreationProposalId");

                            b1.ToTable("ClinicCreationProposals", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("ClinicCreationProposalId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("ClinicName")
                        .IsRequired();

                    b.Navigation("ConfirmationStatus")
                        .IsRequired();
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Clinics.ClinicDoctor", b =>
                {
                    b.HasOne("I3Lab.Clinics.Domain.Clinics.Clinic", null)
                        .WithMany("ClinicDoctors")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("I3Lab.Clinics.Domain.Doctors.Doctor", null)
                        .WithMany("Clinics")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Doctors.Doctor", b =>
                {
                    b.OwnsOne("I3Lab.Clinics.Domain.Doctors.DoctorAvatar", "DoctorAvatar", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("DoctorAvatarUrl");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctor", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("I3Lab.Clinics.Domain.Doctors.DoctorName", "Name", b1 =>
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

                            b1.ToTable("Doctor", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("I3Lab.Clinics.Domain.Doctors.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctor", "clinic");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("I3Lab.Clinics.Domain.Doctors.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctor", "clinic");

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

            modelBuilder.Entity("I3Lab.Clinics.Domain.Clinics.Clinic", b =>
                {
                    b.Navigation("ClinicDoctors");
                });

            modelBuilder.Entity("I3Lab.Clinics.Domain.Doctors.Doctor", b =>
                {
                    b.Navigation("Clinics");
                });
#pragma warning restore 612, 618
        }
    }
}