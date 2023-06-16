using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Taller_BD_existente.Models
{
    public partial class Taller_DAWAContext : DbContext
    {
        public Taller_DAWAContext()
        {
        }

        public Taller_DAWAContext(DbContextOptions<Taller_DAWAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<MetodoPago> MetodoPagos { get; set; } = null!;
        public virtual DbSet<ProductoServicio> ProductoServicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("cliente_id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.ToTable("DetalleFactura");

                entity.Property(e => e.DetalleFacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("detalle_factura_id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength();

                entity.Property(e => e.FacturaId).HasColumnName("factura_id");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.ProductoServicioId).HasColumnName("producto_servicio_id");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK__DetalleFa__factu__45F365D3");

                entity.HasOne(d => d.ProductoServicio)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.ProductoServicioId)
                    .HasConstraintName("FK__DetalleFa__produ__46E78A0C");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("factura_id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength();

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.MetodoPagoId).HasColumnName("metodo_pago_id");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Factura__cliente__3E52440B");

                entity.HasOne(d => d.MetodoPago)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.MetodoPagoId)
                    .HasConstraintName("FK__Factura__metodo___3F466844");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.ToTable("MetodoPago");

                entity.Property(e => e.MetodoPagoId)
                    .ValueGeneratedNever()
                    .HasColumnName("metodo_pago_id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ProductoServicio>(entity =>
            {
                entity.ToTable("ProductoServicio");

                entity.Property(e => e.ProductoServicioId)
                    .ValueGeneratedNever()
                    .HasColumnName("producto_servicio_id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("precio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
