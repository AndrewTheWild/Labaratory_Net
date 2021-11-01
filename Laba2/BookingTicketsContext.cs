using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Laba2
{
    public partial class BookingTicketsContext : DbContext
    {
        public BookingTicketsContext()
        {
        }

        public BookingTicketsContext(DbContextOptions<BookingTicketsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingTicket> BookingTickets { get; set; }
        public virtual DbSet<DirectionInformation> DirectionInformations { get; set; }
        public virtual DbSet<Passeger> Passegers { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<Wagon> Wagons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BookingTickets;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<BookingTicket>(entity =>
            {
                entity.ToTable("BookingTicket");

                entity.HasOne(d => d.Passeger)
                    .WithMany(p => p.BookingTickets)
                    .HasForeignKey(d => d.PassegerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingTicket_Passeger");
            });

            modelBuilder.Entity<DirectionInformation>(entity =>
            {
                entity.ToTable("DirectionInformation");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DateArrival).HasColumnType("datetime");

                entity.Property(e => e.DateDeparture).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Passeger>(entity =>
            {
                entity.ToTable("Passeger");

                entity.Property(e => e.HomeAddress)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Home address");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Last Name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.NumberTrain);

                entity.ToTable("Train");

                entity.Property(e => e.NumberTrain).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Wagon>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("Wagon");

                entity.Property(e => e.Number).ValueGeneratedNever();

                entity.Property(e => e.Type).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
