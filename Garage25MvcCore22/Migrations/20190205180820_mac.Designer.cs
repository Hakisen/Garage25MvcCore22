﻿// <auto-generated />
using System;
using Garage25MvcCore22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage25MvcCore22.Migrations
{
    [DbContext(typeof(Garage25MvcCore22Context))]
    [Migration("20190205180820_mac")]
    partial class mac
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garage25MvcCore22.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNr");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Garage25MvcCore22.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Duration");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("MemberName");

                    b.Property<string>("RegNr");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("TotalPrice");

                    b.HasKey("Id");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("Garage25MvcCore22.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand");

                    b.Property<string>("Color");

                    b.Property<int>("MemberId");

                    b.Property<string>("Model");

                    b.Property<int>("NrOfWheels");

                    b.Property<bool>("Parked");

                    b.Property<string>("RegNr")
                        .IsRequired();

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("VehicleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Garage25MvcCore22.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("VehicleType");
                });

            modelBuilder.Entity("Garage25MvcCore22.Models.Vehicle", b =>
                {
                    b.HasOne("Garage25MvcCore22.Models.Member", "Member")
                        .WithMany("Vehicles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Garage25MvcCore22.Models.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
