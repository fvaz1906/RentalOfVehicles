﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalOfVehicles.Data;

namespace RentalOfVehicles.Migrations.DbRentalVehicles
{
    [DbContext(typeof(DbRentalVehiclesContext))]
    partial class DbRentalVehiclesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RentalOfVehicles.Models.Vehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("RentalOfVehicles.Models.VehiclesReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateReservationFinal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateReservationInitial")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VehiclesId");

                    b.ToTable("VehiclesReservation");
                });

            modelBuilder.Entity("RentalOfVehicles.Models.VehiclesReservation", b =>
                {
                    b.HasOne("RentalOfVehicles.Models.Vehicles", null)
                        .WithMany("VehiclesReservation")
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalOfVehicles.Models.Vehicles", b =>
                {
                    b.Navigation("VehiclesReservation");
                });
#pragma warning restore 612, 618
        }
    }
}
