﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddressLine")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "New York",
                            PostalCode = "21345",
                            State = "New York",
                            StreetAddressLine = "Main Street 32"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Email = "john.smith@mailinator.com",
                            FirstName = "John",
                            LastName = "Smith",
                            Phone = "123-456"
                        });
                });

            modelBuilder.Entity("Domain.Entities.License", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoftwareProductId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ValidFromDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidToDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareProductId");

                    b.ToTable("License", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("License");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.LicenseStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LicenseStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "NA",
                            Description = "Not Activated"
                        },
                        new
                        {
                            Id = 2,
                            Code = "ACT",
                            Description = "Active"
                        },
                        new
                        {
                            Id = 3,
                            Code = "EXP",
                            Description = "Expired"
                        },
                        new
                        {
                            Id = 4,
                            Code = "CA",
                            Description = "Cancelled"
                        });
                });

            modelBuilder.Entity("Domain.Entities.SoftwareLicense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoRenew")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DoesNotExpire")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LicenseCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LicenseName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RenewalPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SoftwareCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("SoftwareName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ValidFromDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ValidToDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("SoftwareLicense", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SoftwareLicenseStatus", b =>
                {
                    b.Property<int>("SoftwareLicenseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LicenseStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SoftwareLicenseStatusDate")
                        .HasColumnType("TEXT");

                    b.HasKey("SoftwareLicenseId", "LicenseStatusId");

                    b.HasIndex("LicenseStatusId");

                    b.ToTable("SoftwareLicenseStatus", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SoftwareProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SoftwareProduct", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ConcurrentLicense", b =>
                {
                    b.HasBaseType("Domain.Entities.License");

                    b.HasDiscriminator().HasValue("ConcurrentLicense");
                });

            modelBuilder.Entity("Domain.Entities.PerpetualLicense", b =>
                {
                    b.HasBaseType("Domain.Entities.License");

                    b.HasDiscriminator().HasValue("PerpetualLicense");
                });

            modelBuilder.Entity("Domain.Entities.SubscriptionBasedLicense", b =>
                {
                    b.HasBaseType("Domain.Entities.License");

                    b.Property<int>("RenewalPeriod")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("SubscriptionBasedLicense");
                });

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.License", b =>
                {
                    b.HasOne("Domain.Entities.SoftwareProduct", "SoftwareProduct")
                        .WithMany("Licenses")
                        .HasForeignKey("SoftwareProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoftwareProduct");
                });

            modelBuilder.Entity("Domain.Entities.SoftwareLicense", b =>
                {
                    b.HasOne("Domain.Entities.Account", "Account")
                        .WithMany("SoftwareLicenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Entities.SoftwareLicenseStatus", b =>
                {
                    b.HasOne("Domain.Entities.LicenseStatus", "LicenseStatus")
                        .WithMany("SoftwareLicenseStatuses")
                        .HasForeignKey("LicenseStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SoftwareLicense", "SoftwareLicense")
                        .WithMany("SoftwareLicenseStatuses")
                        .HasForeignKey("SoftwareLicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicenseStatus");

                    b.Navigation("SoftwareLicense");
                });

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Navigation("SoftwareLicenses");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Domain.Entities.LicenseStatus", b =>
                {
                    b.Navigation("SoftwareLicenseStatuses");
                });

            modelBuilder.Entity("Domain.Entities.SoftwareLicense", b =>
                {
                    b.Navigation("SoftwareLicenseStatuses");
                });

            modelBuilder.Entity("Domain.Entities.SoftwareProduct", b =>
                {
                    b.Navigation("Licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
