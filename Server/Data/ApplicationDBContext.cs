using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using BlazorExamApps.Shared.Models;
using System.Reflection.Emit;

namespace BlazorExamApps.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Elements> Elements { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Windows> Windows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Elements>(entity =>
            {
                entity.ToTable("elements");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Height)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("height");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .HasColumnName("type");

                entity.Property(e => e.Width)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("width");

                entity.Property(e => e.WindowId).HasColumnName("window_id");

                entity.HasOne(d => d.Window)
                    .WithMany(p => p.Elements)
                    .HasForeignKey(d => d.WindowId)
                    .HasConstraintName("FK_elements_windows");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Windows>(entity =>
            {
                entity.ToTable("windows");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Windows)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_windows_windows");
            });
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}
