﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VehicleAPI.Infrastructure.Persistence;

#nullable disable

namespace VehicleAPI.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20230304230441_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VehicleAPI.Core.Domain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("customer_name");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_on");

                    b.Property<DateTime?>("LastPing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_ping");

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reg_nr");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("vin");

                    b.Property<short>("VehicleStatusId")
                        .HasColumnType("smallint")
                        .HasColumnName("vehicle_status_id");

                    b.HasKey("Id")
                        .HasName("pk_vehicle");

                    b.HasIndex("VehicleStatusId")
                        .HasDatabaseName("ix_vehicle_vehicle_status_id");

                    b.ToTable("vehicle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5c5057b0-90cf-4439-a30d-de6929c2faf3"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"),
                            CustomerName = "Kalles Grustransporter AB",
                            RegNr = "ABC123",
                            VIN = "YS2R4X20005399401",
                            VehicleStatusId = (short)2
                        },
                        new
                        {
                            Id = new Guid("8c7f4d32-8bd5-4914-ada2-56c393061e64"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"),
                            CustomerName = "Kalles Grustransporter AB",
                            RegNr = "DEF456",
                            VIN = "VLUR4X20009093588",
                            VehicleStatusId = (short)2
                        },
                        new
                        {
                            Id = new Guid("0c5bb5c0-516f-4c3f-8961-74171d433c0c"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"),
                            CustomerName = "Kalles Grustransporter AB",
                            RegNr = "GHI789",
                            VIN = "VLUR4X20009048066",
                            VehicleStatusId = (short)2
                        },
                        new
                        {
                            Id = new Guid("469b6da0-d0f2-4f74-9598-a365fe965608"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("b906b176-c75b-4a7d-92df-743f626d4fa1"),
                            CustomerName = "Johans Bulk AB",
                            RegNr = "JKL012",
                            VIN = "YS2R4X20005388011",
                            VehicleStatusId = (short)2
                        },
                        new
                        {
                            Id = new Guid("a39e1011-d40d-4b20-840e-4a4a10432694"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("b906b176-c75b-4a7d-92df-743f626d4fa1"),
                            CustomerName = "Johans Bulk AB",
                            RegNr = "MNO345",
                            VIN = "YS2R4X20005387949",
                            VehicleStatusId = (short)2
                        },
                        new
                        {
                            Id = new Guid("6a6d5811-5e19-4789-ad5f-c15065c0e359"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("d0055766-624e-44a8-b3f9-286429716226"),
                            CustomerName = "Haralds Värdetransporter AB",
                            RegNr = "PQR678",
                            VIN = "VLUR4X20009048066",
                            VehicleStatusId = (short)2
                        },
                        new
                        {
                            Id = new Guid("8c181bc6-56f5-4801-a37d-1ad6299a6576"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("d0055766-624e-44a8-b3f9-286429716226"),
                            CustomerName = "Haralds Värdetransporter AB",
                            RegNr = "STU901",
                            VIN = "YS2R4X20005387055",
                            VehicleStatusId = (short)2
                        });
                });

            modelBuilder.Entity("VehicleAPI.Core.Domain.Entities.VehicleStatus", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_vehicle_statues");

                    b.ToTable("vehicle_statues", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Name = "Connected"
                        },
                        new
                        {
                            Id = (short)2,
                            Name = "Disconnected"
                        });
                });

            modelBuilder.Entity("VehicleAPI.Core.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("VehicleAPI.Core.Domain.Entities.VehicleStatus", "VehicleStatus")
                        .WithMany()
                        .HasForeignKey("VehicleStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vehicle_vehicle_statues_vehicle_status_id");

                    b.Navigation("VehicleStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
