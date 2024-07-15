﻿// <auto-generated />
using System;
using BadMintonData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BadMintonData.Migrations
{
    [DbContext(typeof(NET1702_PRN221_BadMintonContext))]
    [Migration("20240715080541_ChangeDateTimeColumns")]
    partial class ChangeDateTimeColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BadMintonData.Models.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BookingID");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("date");

                    b.Property<string>("Code")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("CourtId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CourtID");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerID");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("SlotId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SlotID");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("BookingId");

                    b.HasIndex("CourtId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SlotId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("BadMintonData.Models.BookingDetail", b =>
                {
                    b.Property<Guid>("BookingDetailId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BookingDetailID");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BookingID");

                    b.Property<string>("CourtId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CourtID");

                    b.Property<string>("CustomerId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CustomerID");

                    b.Property<Guid>("SlotId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SlotID");

                    b.HasKey("BookingDetailId");

                    b.HasIndex("BookingId");

                    b.HasIndex("SlotId");

                    b.ToTable("BookingDetail", (string)null);
                });

            modelBuilder.Entity("BadMintonData.Models.Court", b =>
                {
                    b.Property<Guid>("CourtId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CourtID");

                    b.Property<string>("Area")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("BadmintonNet")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CourtName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Descrip")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OwnerName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Seats")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CourtId");

                    b.ToTable("Court", (string)null);
                });

            modelBuilder.Entity("BadMintonData.Models.CourtSlot", b =>
                {
                    b.Property<Guid>("SlotId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SlotID");

                    b.Property<Guid>("CourtId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CourtID");

                    b.Property<DateTime>("SlotEndTime")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.Property<string>("SlotPrice")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("SlotStartTime")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("bit");

                    b.HasKey("SlotId")
                        .HasName("PK__CourtSlo__0A124A4F7BDA49D5");

                    b.HasIndex("CourtId");

                    b.ToTable("CourtSlots");
                });

            modelBuilder.Entity("BadMintonData.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerID");

                    b.Property<string>("Address1")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Address2")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Cccd")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("BadMintonData.Models.Booking", b =>
                {
                    b.HasOne("BadMintonData.Models.Court", "Court")
                        .WithMany("Bookings")
                        .HasForeignKey("CourtId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__CourtI__619B8048");

                    b.HasOne("BadMintonData.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__Custom__60A75C0F");

                    b.HasOne("BadMintonData.Models.CourtSlot", "Slot")
                        .WithMany("Bookings")
                        .HasForeignKey("SlotId")
                        .IsRequired()
                        .HasConstraintName("FK__Bookings__SlotID__628FA481");

                    b.Navigation("Court");

                    b.Navigation("Customer");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("BadMintonData.Models.BookingDetail", b =>
                {
                    b.HasOne("BadMintonData.Models.Booking", "Booking")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("FK_BookingDetail_Booking");

                    b.HasOne("BadMintonData.Models.CourtSlot", "Slot")
                        .WithMany("BookingDetails")
                        .HasForeignKey("SlotId")
                        .IsRequired()
                        .HasConstraintName("FK_BookingDetail_CourtSlots");

                    b.Navigation("Booking");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("BadMintonData.Models.CourtSlot", b =>
                {
                    b.HasOne("BadMintonData.Models.Court", "Court")
                        .WithMany("CourtSlots")
                        .HasForeignKey("CourtId")
                        .IsRequired()
                        .HasConstraintName("FK__CourtSlot__Court__5165187F");

                    b.Navigation("Court");
                });

            modelBuilder.Entity("BadMintonData.Models.Booking", b =>
                {
                    b.Navigation("BookingDetails");
                });

            modelBuilder.Entity("BadMintonData.Models.Court", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("CourtSlots");
                });

            modelBuilder.Entity("BadMintonData.Models.CourtSlot", b =>
                {
                    b.Navigation("BookingDetails");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BadMintonData.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
