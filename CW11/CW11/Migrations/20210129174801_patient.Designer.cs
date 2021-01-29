﻿// <auto-generated />
using System;
using CW11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CW11.Migrations
{
    [DbContext(typeof(s18529Context))]
    [Migration("20210129174801_patient")]
    partial class patient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Cw11.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_key");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "andderj@wp.pl",
                            FirstName = "Andzejr",
                            LastName = "Jezdaeassd"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "hajzio@wp.pl",
                            FirstName = "Filip",
                            LastName = "Hajzer"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "kszuny@wp.pl",
                            FirstName = "Katarzynak",
                            LastName = "Krzak"
                        });
                });

            modelBuilder.Entity("Cw11.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient")
                        .HasName("Patient_key");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            BirthDate = new DateTime(1995, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "LaLa",
                            LastName = "kosta"
                        },
                        new
                        {
                            IdPatient = 2,
                            BirthDate = new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Koko",
                            LastName = "Jambo"
                        },
                        new
                        {
                            IdPatient = 3,
                            BirthDate = new DateTime(1990, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "TuTu",
                            LastName = "Mono"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
