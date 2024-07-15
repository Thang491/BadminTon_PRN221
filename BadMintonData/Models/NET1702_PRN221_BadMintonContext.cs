using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BadMintonData.Models
{
    public partial class NET1702_PRN221_BadMintonContext : DbContext
    {
        public NET1702_PRN221_BadMintonContext()
        {
        }

        public NET1702_PRN221_BadMintonContext(DbContextOptions<NET1702_PRN221_BadMintonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<Court> Courts { get; set; } = null!;
        public virtual DbSet<CourtSlot> CourtSlots { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:DefaultConnectionString"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("BookingID");

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.CourtId).HasColumnName("CourtID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PaymentType).HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.Status).HasMaxLength(255);
                entity.Property(e => e.Code).HasMaxLength(255);
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(255);



                entity.Property(e => e.SlotId).HasColumnName("SlotID");

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings__CourtI__619B8048");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings__Custom__60A75C0F");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings__SlotID__628FA481");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.ToTable("BookingDetail");

                entity.Property(e => e.BookingDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("BookingDetailID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CourtId)
                    .HasMaxLength(50)
                    .HasColumnName("CourtID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.SlotId).HasColumnName("SlotID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingDetail_Booking");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingDetail_CourtSlots");
            });

            modelBuilder.Entity<Court>(entity =>
            {
                entity.ToTable("Court");

                entity.Property(e => e.CourtId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourtID");

                entity.Property(e => e.CourtName).HasMaxLength(255);

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);
                entity.Property(e => e.Descrip).HasMaxLength(255);
                entity.Property(e => e.OwnerName).HasMaxLength(255);
                entity.Property(e => e.Seats).HasMaxLength(255);
                entity.Property(e => e.BadmintonNet).HasMaxLength(255);
                entity.Property(e => e.Area).HasMaxLength(255);

            });

            modelBuilder.Entity<CourtSlot>(entity =>
            {
                entity.HasKey(e => e.SlotId)
                    .HasName("PK__CourtSlo__0A124A4F7BDA49D5");

                entity.Property(e => e.SlotId)
                    .ValueGeneratedNever()
                    .HasColumnName("SlotID");

                entity.Property(e => e.CourtId).HasColumnName("CourtID");

                entity.Property(e => e.SlotEndTime).HasMaxLength(255);

                entity.Property(e => e.SlotPrice).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.SlotStartTime).HasMaxLength(255);

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.CourtSlots)
                    .HasForeignKey(d => d.CourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourtSlot__Court__5165187F");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address1).HasMaxLength(255);
                entity.Property(e => e.Address2).HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.FullName).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(255);
                entity.Property(e => e.CCCD).HasMaxLength(255);
                entity.Property(e => e.Dob).HasColumnType("datetime");
                entity.Property(e => e.Gender).HasColumnType("bit");
                entity.Property(e => e.IsActive).HasColumnType("bit");




            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
