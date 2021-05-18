using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace blog.Areas.admin.Models
{
    public partial class BlogDBContext : DbContext
    {
        public BlogDBContext()
        {
        }

        public BlogDBContext(DbContextOptions<BlogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommentT> CommentTs { get; set; }
        public virtual DbSet<PostT> PostTs { get; set; }
        public virtual DbSet<PostThemeT> PostThemeTs { get; set; }
        public virtual DbSet<ThemeT> ThemeTs { get; set; }
        public virtual DbSet<UserT> UserTs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CommentT>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__Comment___C3B4DFAA00115431");

                entity.ToTable("Comment_t");

                entity.Property(e => e.CommentId)
                    .HasColumnName("CommentID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CommentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CommentText).IsRequired();

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.CommentTs)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment_t__PostI__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentTs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment_t__UserI__2F10007B");
            });

            modelBuilder.Entity<PostT>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__Post_t__AA1260388626B610");

                entity.ToTable("Post_t");

                entity.Property(e => e.PostId)
                    .HasColumnName("PostID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Header)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .HasColumnName("image");

                entity.Property(e => e.PostDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostText)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostTs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post_t__UserID__29572725");
            });

            modelBuilder.Entity<PostThemeT>(entity =>
            {
                entity.HasKey(e => e.PostThemeId)
                    .HasName("PK__PostThem__5AF0777FF145ED96");

                entity.ToTable("PostTheme_t");

                entity.Property(e => e.PostThemeId)
                    .HasColumnName("PostThemeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.ThemeId).HasColumnName("ThemeID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostThemeTs)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PostTheme__PostI__36B12243");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.PostThemeTs)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PostTheme__Theme__37A5467C");
            });

            modelBuilder.Entity<ThemeT>(entity =>
            {
                entity.HasKey(e => e.ThemeId)
                    .HasName("PK__Theme_t__FBB3E4B9DEC99435");

                entity.ToTable("Theme_t");

                entity.Property(e => e.ThemeId)
                    .HasColumnName("ThemeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .HasColumnName("image");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<UserT>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User_t__1788CCACCC97D09C");

                entity.ToTable("User_t");

                entity.HasIndex(e => e.Email, "UQ__User_t__AB6E616446859894")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("email");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .HasColumnName("image");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nickname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
