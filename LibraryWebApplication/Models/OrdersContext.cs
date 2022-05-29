using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryWebApplication
{
    public partial class OrdersContext : DbContext
    {
        public OrdersContext()
        {
        }

        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderService> OrderServices { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Receipt> Receipts { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<TypeOfService> TypeOfServices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               optionsBuilder.UseSqlServer("Server=WIN-RI29PENBJF8\\LOCALDB#F5527CB0;Database=Orders;Trusted_Connection=True;MultipleActiveResultSets=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email).HasMaxLength(25);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.Surname).HasMaxLength(25);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateOfCompletion).HasColumnType("date");

                entity.Property(e => e.DateOfCreation).HasColumnType("date");

                entity.Property(e => e.OrderServicesId).HasColumnName("OrderServicesID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomersOrders");

                entity.HasOne(d => d.OrderServices)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderServicesId)
                    .HasConstraintName("FK_OrderServicesOrders");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_StatusOrders");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.HasKey(e => e.OrderServicesId)
                    .HasName("PK__OrderSer__6FA3FD0A88C0393F");

                entity.Property(e => e.OrderServicesId).HasColumnName("OrderServicesID");

                entity.Property(e => e.PartsId).HasColumnName("PartsID");

                entity.Property(e => e.TypeOfServiceId).HasColumnName("TypeOfServiceID");

                entity.HasOne(d => d.Parts)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.PartsId)
                    .HasConstraintName("FK_PartsOrderServices");

                entity.HasOne(d => d.TypeOfService)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.TypeOfServiceId)
                    .HasConstraintName("FK_TypeOfServicesOrderServices");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasKey(e => e.PartsId)
                    .HasName("PK__Parts__1038D96271F5E7C2");

                entity.Property(e => e.PartsId).HasColumnName("PartsID");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Payer).HasMaxLength(25);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ReceiptsId).HasColumnName("ReceiptsID");

                entity.HasOne(d => d.Receipts)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ReceiptsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Receipts");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptsId)
                    .HasName("PK__Receipts__39CF789EFBE93FFC");

                entity.Property(e => e.ReceiptsId).HasColumnName("ReceiptsID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PaymentAmount).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipts_Orders");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.NameOfStatus).HasMaxLength(30);
            });

            modelBuilder.Entity<TypeOfService>(entity =>
            {
                entity.Property(e => e.TypeOfServiceId).HasColumnName("TypeOfServiceID");

                entity.Property(e => e.PriceOfService).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
