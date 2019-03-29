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
    [Migration("20190329012101_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Salon.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<int?>("GenderId");

                    b.Property<string>("LastName");

                    b.Property<string>("Notes");

                    b.Property<string>("PrimaryEmail");

                    b.Property<string>("PrimaryPhoneNumber");

                    b.Property<string>("SecondaryEmail");

                    b.Property<string>("SecondaryPhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Salon.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<int?>("GenderId");

                    b.Property<DateTime?>("HireDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<int?>("TitleId");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("TitleId");

                    b.ToTable("Employees");
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

            modelBuilder.Entity("Salon.Data.Entities.Customer", b =>
                {
                    b.HasOne("Salon.Data.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("Salon.Data.Entities.Employee", b =>
                {
                    b.HasOne("Salon.Data.Entities.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId");

                    b.HasOne("Salon.Data.Entities.EmployeeTitle", "CurrentTitle")
                        .WithMany("Employees")
                        .HasForeignKey("TitleId");
                });
#pragma warning restore 612, 618
        }
    }
}
