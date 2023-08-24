using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EndavaNetApp.Models;

public partial class TicketManagementSystemContext : DbContext
{
    public TicketManagementSystemContext()
    {
    }

    public TicketManagementSystemContext(DbContextOptions<TicketManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<TotalNumberOfTicketsPerCategory> TotalNumberOfTicketsPerCategories { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6DEN2RN\\SQLEXPRESS;Initial Catalog=Ticket_Management_System;Persist Security Info=True;User ID=oana;Password=12345;TrustServerCertificate=True;encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("PK__customer__B61ED7F5BBA44E07");

            entity.ToTable("customer");

            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Eventid).HasName("PK__event__2DC8B1111FEC2EDC");

            entity.ToTable("event");

            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.EndDate)
                .HasPrecision(6)
                .HasColumnName("end_date");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_description");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_name");
            entity.Property(e => e.EventTypeid).HasColumnName("event_typeid");
            entity.Property(e => e.StartDate)
                .HasPrecision(6)
                .HasColumnName("start_date");
            entity.Property(e => e.Venueid).HasColumnName("venueid");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeid)
                .HasConstraintName("FKefmt1km8bokemo4vs40raqqbg");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.Venueid)
                .HasConstraintName("FKi6e9q306tqiiddx808ul8hn5d");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeid).HasName("PK__event_ty__098CC97D6C108999");

            entity.ToTable("event_type");

            entity.Property(e => e.EventTypeid).HasColumnName("event_typeid");
            entity.Property(e => e.EventTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_type_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PK__orders__080E37756A76EAC0");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.NumberOfTickets).HasColumnName("number_of_tickets");
            entity.Property(e => e.OrderedAt)
                .HasPrecision(6)
                .HasColumnName("ordered_at");
            entity.Property(e => e.TicketCategoryid).HasColumnName("ticket_categoryid");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FKbhieamq65ke02r8ijfso5tivn");

            entity.HasOne(d => d.TicketCategory).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketCategoryid)
                .HasConstraintName("FK8ayya0p1uhlh8owxqdxe2osbc");
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.HasKey(e => e.TicketCategoryid).HasName("PK__ticket_c__45D44DCA0AD49F65");

            entity.ToTable("ticket_category");

            entity.Property(e => e.TicketCategoryid).HasColumnName("ticket_categoryid");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.Eventid)
                .HasConstraintName("FKpclsgt6dy7y5r1tuntx9sk2a5");
        });

        modelBuilder.Entity<TotalNumberOfTicketsPerCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_number_of_tickets_per_category");

            entity.Property(e => e.TicketCategoryid).HasColumnName("ticket_categoryid");
            entity.Property(e => e.TotalNumberOfTickets).HasColumnName("total_number_of_tickets");
            entity.Property(e => e.TotalSales).HasColumnName("total_sales");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Venueid).HasName("PK__venue__4DC0ABE7D098C222");

            entity.ToTable("venue");

            entity.Property(e => e.Venueid).HasColumnName("venueid");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
