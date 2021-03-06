﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Salon.Data;

namespace Salon.Data.Migrations
{
    [DbContext(typeof(SalonContext))]
    [Migration("20190619035324_AddedAppointmentEtcc")]
    partial class AddedAppointmentEtcc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Salon.Data.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Confirmation");

                    b.Property<int?>("CustomerId");

                    b.Property<int>("Duration");

                    b.Property<int?>("EmployeeId");

                    b.Property<bool>("IsPaid");

                    b.Property<bool>("IsPrimaryRequest");

                    b.Property<bool>("IsSecondaryRequest");

                    b.Property<string>("Remarks");

                    b.Property<int?>("ServiceId");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Salon.Data.Entities.AppointmentTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountPaid");

                    b.Property<int>("AppointmentId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("TransactionNote");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentTransactions");
                });

            modelBuilder.Entity("Salon.Data.Entities.EmployeeSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TimeSlotId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("EmployeeSchedules");
                });

            modelBuilder.Entity("Salon.Data.Entities.EmployeeTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTitles");
                });

            modelBuilder.Entity("Salon.Data.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Salon.Data.Entities.GiftCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime?>("DateExpired");

                    b.Property<DateTime?>("DateSold");

                    b.Property<string>("From");

                    b.Property<string>("Note");

                    b.Property<string>("To");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("GiftCards");
                });

            modelBuilder.Entity("Salon.Data.Entities.GiftCardTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountUsed");

                    b.Property<int>("GiftCardId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("TransactionNote");

                    b.HasKey("Id");

                    b.HasIndex("GiftCardId");

                    b.ToTable("GiftCardTransactions");
                });

            modelBuilder.Entity("Salon.Data.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<bool?>("Completed");

                    b.Property<DateTime?>("CompletedOn");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("NoteDescription");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Salon.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<int?>("GenderId");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Salon.Data.Entities.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("Salon.Data.Entities.SalonSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.ToTable("SalonSchedules");
                });

            modelBuilder.Entity("Salon.Data.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ImageSource");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Salon.Data.Entities.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("Salon.Data.Entities.TimeSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration");

                    b.Property<DateTime?>("Start");

                    b.HasKey("Id");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("Salon.Data.Entities.Customer", b =>
                {
                    b.HasBaseType("Salon.Data.Entities.Person");

                    b.Property<string>("Notes");

                    b.Property<string>("PrimaryEmail");

                    b.Property<string>("PrimaryPhoneNumber");

                    b.Property<string>("SecondaryEmail");

                    b.Property<string>("SecondaryPhoneNumber");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("Salon.Data.Entities.Employee", b =>
                {
                    b.HasBaseType("Salon.Data.Entities.Person");

                    b.Property<string>("Address");

                    b.Property<string>("AlternatePhoneNumber");

                    b.Property<DateTime?>("HireDate");

                    b.Property<string>("ImageSource");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastInitial");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Remarks");

                    b.Property<int?>("TitleId");

                    b.HasIndex("TitleId");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Salon.Data.Entities.Appointment", b =>
                {
                    b.HasOne("Salon.Data.Entities.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Salon.Data.Entities.Employee", "Employee")
                        .WithMany("EmployeeAppointments")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Salon.Data.Entities.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId");
                });

            modelBuilder.Entity("Salon.Data.Entities.AppointmentTransaction", b =>
                {
                    b.HasOne("Salon.Data.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentTransactions")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salon.Data.Entities.EmployeeSchedule", b =>
                {
                    b.HasOne("Salon.Data.Entities.Employee", "Employee")
                        .WithMany("EmployeeSchedules")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Salon.Data.Entities.TimeSlot", "TimeSlot")
                        .WithMany("EmployeeSchedules")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salon.Data.Entities.GiftCard", b =>
                {
                    b.HasOne("Salon.Data.Entities.Customer", "Customer")
                        .WithMany("GiftCards")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Salon.Data.Entities.GiftCardTransaction", b =>
                {
                    b.HasOne("Salon.Data.Entities.GiftCard", "GiftCard")
                        .WithMany("GiftCardTransactions")
                        .HasForeignKey("GiftCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salon.Data.Entities.Note", b =>
                {
                    b.HasOne("Salon.Data.Entities.Employee", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("Salon.Data.Entities.Person", b =>
                {
                    b.HasOne("Salon.Data.Entities.Gender", "Gender")
                        .WithMany("People")
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("Salon.Data.Entities.Qualification", b =>
                {
                    b.HasOne("Salon.Data.Entities.Employee", "Employee")
                        .WithMany("EmployeeQualifications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Salon.Data.Entities.Service", "Service")
                        .WithMany("Qualifications")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Salon.Data.Entities.Service", b =>
                {
                    b.HasOne("Salon.Data.Entities.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Salon.Data.Entities.Employee", b =>
                {
                    b.HasOne("Salon.Data.Entities.EmployeeTitle", "CurrentTitle")
                        .WithMany("Employees")
                        .HasForeignKey("TitleId");
                });
#pragma warning restore 612, 618
        }
    }
}
