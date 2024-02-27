﻿// <auto-generated />
using System;
using EFCoreExample;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCoreExample.Migrations
{
    [DbContext(typeof(EFCoreCodeFirstDBContext))]
    [Migration("20240226183026_UpdateUsserOrderProduct")]
    partial class UpdateUsserOrderProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFCoreExample.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EFCoreExample.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EFCoreExample.Entity.UserDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("EFCoreExample.Entity.UserOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrder");
                });

            modelBuilder.Entity("EFCoreExample.Entity.UserOrderProduct", b =>
                {
                    b.Property<int>("UserOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("UserOrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserOrderProduct");
                });

            modelBuilder.Entity("EFCoreExample.Entity.UserDetails", b =>
                {
                    b.HasOne("EFCoreExample.Entity.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("EFCoreExample.Entity.UserDetails", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFCoreExample.Entity.UserOrder", b =>
                {
                    b.HasOne("EFCoreExample.Entity.User", "User")
                        .WithMany("UserOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFCoreExample.Entity.UserOrderProduct", b =>
                {
                    b.HasOne("EFCoreExample.Entity.Product", "Product")
                        .WithMany("UserOrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreExample.Entity.UserOrder", "UserOrder")
                        .WithMany("UserOrderProducts")
                        .HasForeignKey("UserOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("UserOrder");
                });

            modelBuilder.Entity("EFCoreExample.Entity.Product", b =>
                {
                    b.Navigation("UserOrderProducts");
                });

            modelBuilder.Entity("EFCoreExample.Entity.User", b =>
                {
                    b.Navigation("UserDetails");

                    b.Navigation("UserOrders");
                });

            modelBuilder.Entity("EFCoreExample.Entity.UserOrder", b =>
                {
                    b.Navigation("UserOrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
