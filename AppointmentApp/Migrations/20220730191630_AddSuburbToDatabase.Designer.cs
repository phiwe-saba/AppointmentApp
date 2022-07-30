﻿// <auto-generated />
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
    [Migration("20220730191630_AddSuburbToDatabase")]
    partial class AddSuburbToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
#pragma warning restore 612, 618
        }
    }
}