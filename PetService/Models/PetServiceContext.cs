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

        public virtual DbSet<Mascotas> Mascotas { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GVP8GJ2\\SQLEXPRESS;Database=PetService;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascotas>(entity =>
            {
                entity.HasKey(e => e.IdMascota);

                entity.Property(e => e.Estatura).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FotoMascota).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Peso).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Mascotas_Usuarios");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Contra)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Edad).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
