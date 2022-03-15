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
        public virtual DbSet<Mascota> Mascota { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Propietario> Propietarios { get; set; } = null!;
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

                entity.HasComment("Tabla citas, donde se asigna el id de la mascota y el propietario para cada servicio; por supuesto para asignación ");

                entity.Property(e => e.IdCita).HasComment("Campo IdCita es el identificador utilizado para cada cita.");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasComment("Campo Descripcion, atributo para designar el motivo de cita y/o lo que se va a hacer.");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasComment("Campo Fecha, atributo de tiempo para designar el día de la cita.");

                entity.Property(e => e.IdMascota).HasComment("Campo IdMascota, llave foránea que conecta con la tabla de mascotas que corresponde al perro de la persona.");

                entity.Property(e => e.IdServicio).HasComment("Campo IdServicio, llave foránea que conecta con la tabla de servicios para asignarse en cada cita.");

                entity.Property(e => e.IdUsuario).HasComment("Campo IdUsuario, llave foránea que conecta con la tabla de usuarios que corresponde al dueño del perro.");

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

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                    .HasName("PK_Perros");

                entity.HasComment("Tabla Mascota, donde se almacena la información de la mascota.");

                entity.Property(e => e.IdMascota).HasComment("Campo IdMascota, llave principal de la tabla.");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasComment("Campo FechaNacimiento, indica la edad de la mascota y su fecha de nacimiento.");

                entity.Property(e => e.FotoMascota).IsUnicode(false);

                entity.Property(e => e.IdPropietario).HasComment("Campo IdUsuario, llave foránea que conecta con la tabla de usuarios para señalar al propietario del animal.");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Campo Nombre, indica el nombre del animal.");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Campo Sexo, indica el sexo de la mascota.");

                entity.HasOne(d => d.IdPropietarioNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.IdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mascota_Propietario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProductos)
                    .HasName("PK_Productos");

                entity.ToTable("Producto");

                entity.HasComment("Tabla Producto, donde se almacena la información de cada producto a la venta.");

                entity.Property(e => e.IdProductos).HasComment("Campo IdProductos, llave primaria en la tabla de productos.");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasComment("Campo Descripcion, da una descripción de lo que hace o es el artículo.");

                entity.Property(e => e.FotoProducto)
                    .IsUnicode(false)
                    .HasComment("Campo FotoProducto, guarda la información (URL) para una foto del producto.")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Inventario).HasComment("Campo Inventario, cantidad del producto disponible.");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Campo NombreProducto, indica el nombre producto.")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.Precio).HasComment("Campo Precio, precio del producto.");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasKey(e => e.IdPropietario);

                entity.ToTable("Propietario");

                entity.HasIndex(e => e.Telefono, "IX_Propietario")
                    .IsUnique();

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Campo ApellidoM, indica el apellido materno del usuario.");

                entity.Property(e => e.ApellidoP)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Campo ApellidoP, indica el apellido paterno del usuario.");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasComment("Campo FechaNacimiento, indica su cumpleaños para calcular edad.");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Campo Nombres, indica uno o los dos nombres de las posibles usuarios.");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("Campo Sexo, indica el sexo del usuario.");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Campo Telefono, indica el telefono del usuario.");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Propietarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Propietario_Usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("Rol");

                entity.HasComment("Tabla Rol, donde se indica los tipos de roles en  cuanto a usuarios o administadores.");

                entity.HasIndex(e => e.NombreDescripcion, "IX_Rol")
                    .IsUnique();

                entity.Property(e => e.IdRol).HasComment("Campo IdRol, llave primaria en la tabla roles.");

                entity.Property(e => e.NombreDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Campo NombreDescripcion, se indica el tipo de usuarios o administrador que pueda haber en el programa.")
                    .UseCollation("Modern_Spanish_CI_AS");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK_Servicios");

                entity.ToTable("Servicio");

                entity.HasComment("Tabla Servicio, donde se almacenan los diferentes tipos de servicios.");

                entity.HasIndex(e => e.NombreServicio, "IX_Servicio")
                    .IsUnique();

                entity.Property(e => e.IdServicio).HasComment("Campo IdServicio, llave primaria en la tabla Servicio.");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuarios");

                entity.ToTable("Usuario");

                entity.HasComment("Tabla Usuario, donde se almacenan los diferentes tipos de servicios.");

                entity.Property(e => e.IdUsuario).HasComment("Campo IdUsuario, llave primaria en la tabla Usuario.");

                entity.Property(e => e.Contra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Campo Contra, indica la contraseña de la cuenta del usuario.");

                entity.Property(e => e.Correo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Campo Correo, indica el correo o email del usuario.");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasComment("Campo FechaActualizacion, almacena la fecha de actualización de la cuenta.");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasComment("Campo FechaCreacion, almacena la fecha de creación de la cuenta.");

                entity.Property(e => e.FotoPerfil)
                    .IsUnicode(false)
                    .HasComment("Campo FotoPerfil, foto del usario.");

                entity.Property(e => e.IdRol).HasComment("Campo IdRol, llave foránea que conecta con la tabla Rol.");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Campo RememberToken, usado como código de seguridad para recuperar la cuenta o cambiar contraseña.")
                    .UseCollation("Modern_Spanish_CI_AS");

                entity.Property(e => e.VerificacionEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Campo VerificacionEmail, es un código de seguridad enviado al email al guardar información, como seguridad.")
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

                entity.HasComment("Tabla Venta_Detalle, donde se almacenan los detalles de cada venta.");

                entity.Property(e => e.IdVentaDetalle).HasComment("Campo IdVentaDetalle, llave primaria en la tabla Venta_Detalle.");

                entity.Property(e => e.Cantidad).HasComment("Campo Cantidad, campo que describe la cantidad de algún producto comprado.");

                entity.Property(e => e.Costo).HasComment("Campo Costo, campo que da el precio del producto, servicio, cita... Etc, al usuario.");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasComment("Campo Descripcion, campo que describe el detalle del registro.");

                entity.Property(e => e.IdProducto).HasComment("Campo IdProducto, llave foránea que conecta con la tabla Producto.");

                entity.Property(e => e.IdVenta).HasComment("Campo IdVenta, llave foránea que conecta con la tabla Venta.");

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

                entity.HasComment("Tabla Venta, donde se almacenan los registros de venta.");

                entity.Property(e => e.IdVenta).HasComment("Campo IdVenta, llave primaria en la tabla Venta.");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasComment("Campo Fecha, campo que guarda la fecha efectuada de la venta.");

                entity.Property(e => e.IdUsuario).HasComment("Campo IdUsuario, llave foránea que conecta con la tabla Usuario.");

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
