﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResturantApp.Models;

#nullable disable

namespace ResturantApp.Migrations
{
    [DbContext(typeof(ResturantAppContext))]
    [Migration("20240224225752_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("ResturantApp.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ResturantApp.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MenuItemName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StaffId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MenuItemId");

                    b.HasIndex("StaffId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("ResturantApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StaffId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ResturantApp.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReservationDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StaffId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ResturantApp.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffName")
                        .HasColumnType("TEXT");

                    b.HasKey("StaffId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("ResturantApp.Models.MenuItem", b =>
                {
                    b.HasOne("ResturantApp.Models.Staff", null)
                        .WithMany("Items")
                        .HasForeignKey("StaffId");
                });

            modelBuilder.Entity("ResturantApp.Models.Order", b =>
                {
                    b.HasOne("ResturantApp.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantApp.Models.Staff", null)
                        .WithMany("Orders")
                        .HasForeignKey("StaffId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ResturantApp.Models.Reservation", b =>
                {
                    b.HasOne("ResturantApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantApp.Models.Staff", null)
                        .WithMany("Reservations")
                        .HasForeignKey("StaffId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ResturantApp.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ResturantApp.Models.Staff", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Orders");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
