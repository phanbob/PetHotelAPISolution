using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BussinessObject.Models;

public partial class PetsHotelContext : DbContext
{
    public PetsHotelContext()
    {
    }

    public PetsHotelContext(DbContextOptions<PetsHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetOwner> PetOwners { get; set; }

    public virtual DbSet<PetType> PetTypes { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Stay> Stays { get; set; }

    public virtual DbSet<StayService> StayServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-P9DKHQ4;Database=PetsHotel;User Id=sa;Password=4444;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__Pet__48E53862996277FB");

            entity.ToTable("Pet");

            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.Pets)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Pet__OwnerId__44FF419A");

            entity.HasOne(d => d.PetType).WithMany(p => p.Pets)
                .HasForeignKey(d => d.PetTypeId)
                .HasConstraintName("FK__Pet__PetTypeId__45F365D3");
        });

        modelBuilder.Entity<PetOwner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__PetOwner__819385B834824654");

            entity.ToTable("PetOwner");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PetType>(entity =>
        {
            entity.HasKey(e => e.PetTypeId).HasName("PK__PetType__F8A12547A0530310");

            entity.ToTable("PetType");

            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__32863939FEDA8EF4");

            entity.ToTable("Room");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.ToTable("RoomType");

            entity.Property(e => e.RoomTypeId).ValueGeneratedNever();
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.RoomName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.RoomTypeNavigation).WithOne(p => p.RoomType)
                .HasForeignKey<RoomType>(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomType_Rooms");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB00A33452A49");

            entity.ToTable("Service");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Stay>(entity =>
        {
            entity.HasKey(e => e.StayId).HasName("PK__Stay__04BA16A6D98B8536");

            entity.ToTable("Stay");

            entity.Property(e => e.CheckInDate).HasColumnType("date");
            entity.Property(e => e.CheckOutDate).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Pet).WithMany(p => p.Stays)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stay__PetId__47DBAE45");

            entity.HasOne(d => d.Room).WithMany(p => p.Stays)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stays__RoomId__45F365D3");
        });

        modelBuilder.Entity<StayService>(entity =>
        {
            entity.HasKey(e => e.StayServicesId).HasName("PK__StayServ__AE0218DE899A80F1");

            entity.ToTable("StayService");

            entity.HasOne(d => d.Service).WithMany(p => p.StayServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__StayServi__Servi__49C3F6B7");

            entity.HasOne(d => d.Stay).WithMany(p => p.StayServices)
                .HasForeignKey(d => d.StayId)
                .HasConstraintName("FK__StayServi__StayI__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
