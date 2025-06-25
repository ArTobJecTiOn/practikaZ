using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practikaZ.models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userachievement> Userachievements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=practice;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achievements_pkey");

            entity.ToTable("achievements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("announcement_pkey");

            entity.ToTable("announcement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.TargetPostId).HasColumnName("target_post_id");
            entity.Property(e => e.TargetRoleId).HasColumnName("target_role_id");
            entity.Property(e => e.TargetSpecializationId).HasColumnName("target_specialization_id");
            entity.Property(e => e.TargetUserId).HasColumnName("target_user_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.AnnouncementAuthors)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("announcement_author_id_fkey");

            entity.HasOne(d => d.TargetPost).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.TargetPostId)
                .HasConstraintName("announcement_target_post_id_fkey");

            entity.HasOne(d => d.TargetRole).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.TargetRoleId)
                .HasConstraintName("announcement_target_role_id_fkey");

            entity.HasOne(d => d.TargetSpecialization).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.TargetSpecializationId)
                .HasConstraintName("announcement_target_specialization_id_fkey");

            entity.HasOne(d => d.TargetUser).WithMany(p => p.AnnouncementTargetUsers)
                .HasForeignKey(d => d.TargetUserId)
                .HasConstraintName("announcement_target_user_id_fkey");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender1)
                .HasMaxLength(10)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasColumnName("order_status");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_user_id_fkey");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("posts_pkey");

            entity.ToTable("posts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PostName)
                .HasMaxLength(100)
                .HasColumnName("post_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("specializations_pkey");

            entity.ToTable("specializations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SpecializationName)
                .HasMaxLength(100)
                .HasColumnName("specialization_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.JobPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Job_phone_number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_gender_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.Users)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_post_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_fkey");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Users)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_specialization_id_fkey");
        });

        modelBuilder.Entity<Userachievement>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AchievementId }).HasName("pk_userachievements");

            entity.ToTable("userachievements");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AchievementId).HasColumnName("achievement_id");
            entity.Property(e => e.Desc)
                .HasColumnType("character varying")
                .HasColumnName("desc");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Userachievements)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userachievements_achievement");

            entity.HasOne(d => d.User).WithMany(p => p.Userachievements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userachievements_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
