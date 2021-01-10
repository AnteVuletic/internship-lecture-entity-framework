﻿// <auto-generated />
using System;
using Lecture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lecture.Data.Migrations
{
    [DbContext(typeof(RentACarDbContext))]
    [Migration("20210110103657_EndOfRentNullable")]
    partial class EndOfRentNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Lecture.Data.Entities.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DrivingLicenseIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oib")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndOfRent")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentRateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartOfRent")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RentRateId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.RentRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentRateType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RentRates");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Kilometers")
                        .HasColumnType("int");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.VehicleBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleBrands");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Registration", b =>
                {
                    b.HasOne("Lecture.Data.Entities.Models.Vehicle", "Vehicle")
                        .WithMany("Registrations")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Rent", b =>
                {
                    b.HasOne("Lecture.Data.Entities.Models.Customer", "Customer")
                        .WithMany("Rents")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lecture.Data.Entities.Models.Employee", "Employee")
                        .WithMany("Rents")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lecture.Data.Entities.Models.RentRate", "RentRate")
                        .WithMany("Rents")
                        .HasForeignKey("RentRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lecture.Data.Entities.Models.Vehicle", "Vehicle")
                        .WithMany("Rents")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("RentRate");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Vehicle", b =>
                {
                    b.HasOne("Lecture.Data.Entities.Models.VehicleModel", "VehicleModel")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.VehicleModel", b =>
                {
                    b.HasOne("Lecture.Data.Entities.Models.VehicleBrand", "Brand")
                        .WithMany("VehicleModels")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Customer", b =>
                {
                    b.Navigation("Rents");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Employee", b =>
                {
                    b.Navigation("Rents");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.RentRate", b =>
                {
                    b.Navigation("Rents");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.Vehicle", b =>
                {
                    b.Navigation("Registrations");

                    b.Navigation("Rents");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.VehicleBrand", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("Lecture.Data.Entities.Models.VehicleModel", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
