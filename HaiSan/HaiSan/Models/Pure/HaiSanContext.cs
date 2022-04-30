using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HaiSan.Models.Pure
{
    public partial class HaiSanContext : DbContext
    {
        public HaiSanContext()
        {
        }

        public HaiSanContext(DbContextOptions<HaiSanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Giohang> Giohangs { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Loaisp> Loaisps { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HaiSan;Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__comments__57C9AD58B97C760A");

                entity.ToTable("comments");

                entity.Property(e => e.IdComment)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comment1).HasColumnName("Comment");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaSP");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK__comments__MaSP__1ED998B2");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__comments__Userna__1FCDBCEB");
            });

            modelBuilder.Entity<Giohang>(entity =>
            {
                entity.HasKey(e => e.IdGioHang)
                    .HasName("PK__GIOHANG__CCE77A1F068EBE86");

                entity.ToTable("GIOHANG");

                entity.Property(e => e.IdGioHang)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardHolder)
                    .HasMaxLength(100)
                    .HasColumnName("cardHolder");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cardNumber");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("date")
                    .HasColumnName("dateUpdated");

                entity.Property(e => e.Expired)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("expired");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Giohangs)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__GIOHANG__Usernam__22AA2996");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.IdGioHang })
                    .HasName("PK__Item__CBEB7FBD769D2DA3");

                entity.ToTable("Item");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaSP");

                entity.Property(e => e.IdGioHang)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("date")
                    .HasColumnName("dateUpdated");

                entity.Property(e => e.GiamGia).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdGioHangNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdGioHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__IdGioHang__267ABA7A");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__MaSP__25869641");
            });

            modelBuilder.Entity<Loaisp>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LOAISP__3E1DB46DF31A0DBE");

                entity.ToTable("LOAISP");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Path).IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SANPHAM__2725081C501B2F22");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MaSP");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("dateCreated");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdSize)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSizeNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdSize)
                    .HasConstraintName("FK__SANPHAM__IdSize__1A14E395");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK__SANPHAM__MaLoai__1B0907CE");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__SANPHAM__Usernam__1BFD2C07");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.IdSize)
                    .HasName("PK__SIZE__A683FEA53226E43D");

                entity.ToTable("SIZE");

                entity.Property(e => e.IdSize)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Size1)
                    .HasMaxLength(100)
                    .HasColumnName("Size");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Users__536C85E571464384");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleId__173876EA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
