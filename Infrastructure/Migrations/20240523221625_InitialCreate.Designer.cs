﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20240523221625_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

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

                    b.ToTable("Licenses", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("License");

                    b.UseTphMappingStrategy();
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

                    b.ToTable("SoftwareProducts");
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

            modelBuilder.Entity("Domain.Entities.License", b =>
                {
                    b.HasOne("Domain.Entities.SoftwareProduct", "SoftwareProduct")
                        .WithMany("Licenses")
                        .HasForeignKey("SoftwareProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoftwareProduct");
                });

            modelBuilder.Entity("Domain.Entities.SoftwareProduct", b =>
                {
                    b.Navigation("Licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
