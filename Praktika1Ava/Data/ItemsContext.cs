using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Praktika1Ava.Data;

public partial class ItemsContext : DbContext
{
    public ItemsContext()
    {
    }

    public ItemsContext(DbContextOptions<ItemsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserItem> UserItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Praktika1;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Item_pkey");

            entity.ToTable("Item");

            entity.Property(e => e.Desc).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<UserItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_Item_pkey");

            entity.ToTable("User_Item");

            entity.Property(e => e.ItemId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Item_Id");
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("User_Id");

            entity.HasOne(d => d.Item).WithMany(p => p.UserItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_Item_Item_Id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_Item_User_Id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
