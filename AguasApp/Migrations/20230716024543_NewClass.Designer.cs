﻿// <auto-generated />
using System;
using AguasApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AguasApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230716024543_NewClass")]
    partial class NewClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AguasApp.Data.Entities.Consumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Escalation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("VolumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("Consumptions");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractNumber")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerNameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("MonthlyValue")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerNameId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.CustomerService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssociatedCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CallStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTimeOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProblemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedCustomerId");

                    b.ToTable("CustomerServices");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.DistributionNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<int?>("WaterMeterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TechnicianId");

                    b.HasIndex("WaterMeterId");

                    b.ToTable("DistributionNetworks");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AmountToPay")
                        .HasColumnType("real");

                    b.Property<int?>("AssociatedCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedCustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.MeterReading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssociatedCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RegisteredConsumptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedCustomerId");

                    b.HasIndex("RegisteredConsumptionId");

                    b.ToTable("MeterReadings");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Filters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metadata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCustomersServed")
                        .HasColumnType("int");

                    b.Property<string>("ReportType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Revenue")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalLitersConsumed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Technician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.WaterMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CurrentReading")
                        .HasColumnType("float");

                    b.Property<string>("ImageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WaterMeters");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Consumption", b =>
                {
                    b.HasOne("AguasApp.Data.Entities.WaterMeter", "Volume")
                        .WithMany()
                        .HasForeignKey("VolumeId");

                    b.Navigation("Volume");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Contract", b =>
                {
                    b.HasOne("AguasApp.Data.Entities.Customer", "CustomerName")
                        .WithMany()
                        .HasForeignKey("CustomerNameId");

                    b.Navigation("CustomerName");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.CustomerService", b =>
                {
                    b.HasOne("AguasApp.Data.Entities.Customer", "AssociatedCustomer")
                        .WithMany()
                        .HasForeignKey("AssociatedCustomerId");

                    b.Navigation("AssociatedCustomer");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.DistributionNetwork", b =>
                {
                    b.HasOne("AguasApp.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("AguasApp.Data.Entities.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.HasOne("AguasApp.Data.Entities.WaterMeter", "WaterMeter")
                        .WithMany()
                        .HasForeignKey("WaterMeterId");

                    b.Navigation("Customer");

                    b.Navigation("Technician");

                    b.Navigation("WaterMeter");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.Invoice", b =>
                {
                    b.HasOne("AguasApp.Data.Entities.Customer", "AssociatedCustomer")
                        .WithMany()
                        .HasForeignKey("AssociatedCustomerId");

                    b.Navigation("AssociatedCustomer");
                });

            modelBuilder.Entity("AguasApp.Data.Entities.MeterReading", b =>
                {
                    b.HasOne("AguasApp.Data.Entities.Customer", "AssociatedCustomer")
                        .WithMany()
                        .HasForeignKey("AssociatedCustomerId");

                    b.HasOne("AguasApp.Data.Entities.Consumption", "RegisteredConsumption")
                        .WithMany()
                        .HasForeignKey("RegisteredConsumptionId");

                    b.Navigation("AssociatedCustomer");

                    b.Navigation("RegisteredConsumption");
                });
#pragma warning restore 612, 618
        }
    }
}
