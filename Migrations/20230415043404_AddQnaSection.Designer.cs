﻿// <auto-generated />
using System;
using HospitalManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagementAPI.Migrations
{
    [DbContext(typeof(HospitalManagementContext))]
    [Migration("20230415043404_AddQnaSection")]
    partial class AddQnaSection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagementAPI.Models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("_admins");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppointmentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPatient")
                        .HasColumnType("bit");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("_appointments");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("_doctors");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Dose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrescriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("_medicines");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.NonPatientAppointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppointmentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PatientContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientNric")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("_nonPatientAppointments");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NRIC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("_patients");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.PatientHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("appointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("doctorInChargeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("patientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("doctorInChargeId");

                    b.HasIndex("patientId");

                    b.ToTable("_patientHistory");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Pharmacist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("_pharmacists");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NonPatientAppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PatientHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isCollected")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("NonPatientAppointmentId");

                    b.HasIndex("PatientHistoryId");

                    b.ToTable("_prescriptions");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.QnA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("_qNA");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.RoleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserDetailId");

                    b.ToTable("_roleModels");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.UserModal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("lastLogin")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("_userModels");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Medicine", b =>
                {
                    b.HasOne("HospitalManagementAPI.Models.Prescription", null)
                        .WithMany("medicine")
                        .HasForeignKey("PrescriptionId");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.PatientHistory", b =>
                {
                    b.HasOne("HospitalManagementAPI.Models.Doctor", "doctorInCharge")
                        .WithMany()
                        .HasForeignKey("doctorInChargeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementAPI.Models.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctorInCharge");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Prescription", b =>
                {
                    b.HasOne("HospitalManagementAPI.Models.Appointment", "Appointment")
                        .WithMany("prescriptions")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementAPI.Models.NonPatientAppointment", null)
                        .WithMany("prescriptions")
                        .HasForeignKey("NonPatientAppointmentId");

                    b.HasOne("HospitalManagementAPI.Models.PatientHistory", null)
                        .WithMany("prescriptions")
                        .HasForeignKey("PatientHistoryId");

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.RoleModel", b =>
                {
                    b.HasOne("HospitalManagementAPI.Models.UserModal", "UserDetail")
                        .WithMany()
                        .HasForeignKey("UserDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Appointment", b =>
                {
                    b.Navigation("prescriptions");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.NonPatientAppointment", b =>
                {
                    b.Navigation("prescriptions");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.PatientHistory", b =>
                {
                    b.Navigation("prescriptions");
                });

            modelBuilder.Entity("HospitalManagementAPI.Models.Prescription", b =>
                {
                    b.Navigation("medicine");
                });
#pragma warning restore 612, 618
        }
    }
}
