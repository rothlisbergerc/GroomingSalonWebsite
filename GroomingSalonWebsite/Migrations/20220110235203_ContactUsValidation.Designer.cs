﻿// <auto-generated />
using System;
using GroomingSalonWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroomingSalonWebsite.Migrations
{
    [DbContext(typeof(SalonContext))]
    [Migration("20220110235203_ContactUsValidation")]
    partial class ContactUsValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroomingSalonWebsite.Models.About", b =>
                {
                    b.Property<int>("aboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("aboutText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("aboutId");

                    b.ToTable("About");
                });

            modelBuilder.Entity("GroomingSalonWebsite.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApptAddress1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApptAddress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApptCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApptDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApptFirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ApptLastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("ApptPetBirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApptPetBreed")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ApptPetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApptPetWeight")
                        .HasColumnType("int");

                    b.Property<string>("ApptPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ApptServices")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApptState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApptZipcode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("AppointmentId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("GroomingSalonWebsite.Models.ContactUs", b =>
                {
                    b.Property<int>("messageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hearabout")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("messageId");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("GroomingSalonWebsite.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GroomingSalonWebsite.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Age")
                        .HasColumnType("real");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PetId");

                    b.ToTable("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
