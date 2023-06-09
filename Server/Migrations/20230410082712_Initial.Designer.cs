﻿// <auto-generated />
using System;
using BlazorExamApps.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorExamApps.Server.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230410082712_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorExamApps.Shared.Models.Elements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("height");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("type");

                    b.Property<decimal?>("Width")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("width");

                    b.Property<int?>("WindowId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("window_id");

                    b.HasKey("Id");

                    b.HasIndex("WindowId");

                    b.ToTable("elements", (string)null);
                });

            modelBuilder.Entity("BlazorExamApps.Shared.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("BlazorExamApps.Shared.Models.Windows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<int?>("OrderId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("windows", (string)null);
                });

            modelBuilder.Entity("BlazorExamApps.Shared.Models.Elements", b =>
                {
                    b.HasOne("BlazorExamApps.Shared.Models.Windows", "Window")
                        .WithMany("Elements")
                        .HasForeignKey("WindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_elements_windows");

                    b.Navigation("Window");
                });

            modelBuilder.Entity("BlazorExamApps.Shared.Models.Windows", b =>
                {
                    b.HasOne("BlazorExamApps.Shared.Models.Orders", "Order")
                        .WithMany("Windows")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_windows_windows");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BlazorExamApps.Shared.Models.Orders", b =>
                {
                    b.Navigation("Windows");
                });

            modelBuilder.Entity("BlazorExamApps.Shared.Models.Windows", b =>
                {
                    b.Navigation("Elements");
                });
#pragma warning restore 612, 618
        }
    }
}
