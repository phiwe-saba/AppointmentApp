﻿// <auto-generated />
using System;
using AppointmentApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentApp.Migrations
{
    [DbContext(typeof(AppointmentDbContext))]
    [Migration("20220801145108_AddAppointmentToDatabase")]
    partial class AddAppointmentToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppointmentApp.Models.Appointment", b =>
                {
                    b.Property<int>("AppId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppId"), 1L, 1);

                    b.Property<DateTime>("AppDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AppTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Doctor")
                        .HasColumnType("int");

                    b.Property<int>("DoctorsDoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("AppId");

                    b.HasIndex("DoctorsDoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("AppointmentApp.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AppointmentApp.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("AppointmentApp.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"), 1L, 1);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
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

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuburbId")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.HasIndex("SuburbId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("AppointmentApp.Models.Suburb", b =>
                {
                    b.Property<int>("SuburbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuburbId"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("SuburbName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuburbId");

                    b.HasIndex("CityId");

                    b.ToTable("Suburbs");
                });

            modelBuilder.Entity("AppointmentApp.Models.Appointment", b =>
                {
                    b.HasOne("AppointmentApp.Models.Doctor", "Doctors")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorsDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppointmentApp.Models.Patient", "Patients")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("AppointmentApp.Models.Patient", b =>
                {
                    b.HasOne("AppointmentApp.Models.Suburb", "Suburb")
                        .WithMany("Patient")
                        .HasForeignKey("SuburbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suburb");
                });

            modelBuilder.Entity("AppointmentApp.Models.Suburb", b =>
                {
                    b.HasOne("AppointmentApp.Models.City", "City")
                        .WithMany("Suburbs")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("AppointmentApp.Models.City", b =>
                {
                    b.Navigation("Suburbs");
                });

            modelBuilder.Entity("AppointmentApp.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("AppointmentApp.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("AppointmentApp.Models.Suburb", b =>
                {
                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
