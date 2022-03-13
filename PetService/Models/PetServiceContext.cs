using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetService.Models
{
    public partial class PetServiceContext : DbContext
    {
        public PetServiceContext()
        {
        }

        public PetServiceContext(DbContextOptions<PetServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Cita { get; set; } = null!;
        public virtual DbSet<FotoMascota> FotoMascota { get; set; } = null!;
        public virtual DbSet<Mascota> Mascota { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<VentaDetalle> VentaDetalles { get; set; } = null!;
        public virtual DbSet<Venta> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PetService.mssql.somee.com;Database=PetService;User Id= A204_SQLLogin_1; Password=j5yyu4x8up;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK_Citas");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdMascotaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdMascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cita_Mascota");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK_Cita_Servicio");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cita_Usuario");
            });

            modelBuilder.Entity<FotoMascota>(entity =>
            {
                entity.HasKey(e => e.IdFotoMascota);

                entity.Property(e => e.Foto1)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Foto2)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Foto3)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                    .HasName("PK_Perros");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFotoMascotaNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdFotoMascota)
                    .HasConstraintName("FK_Mascota_FotoMascota");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mascota_Usuario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProductos)
                    .HasName("PK_Productos");

                entity.ToTable("Producto");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.FotoProducto)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("Rol");

                entity.HasIndex(e => e.NombreDescripcion, "IX_Rol")
                    .IsUnique();

                entity.Property(e => e.NombreDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK_Servicios");

                entity.ToTable("Servicio");

                entity.HasIndex(e => e.NombreServicio, "IX_Servicio")
                    .IsUnique();

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuarios");

                entity.ToTable("Usuario");

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contra)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FotoPerfil).IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VerificacionEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            modelBuilder.Entity<VentaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdVentaDetalle);

                entity.ToTable("Venta_Detalle");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.VentaDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Detalle_Producto");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.VentaDetalles)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Detalle_Venta");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK_Ventas");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
