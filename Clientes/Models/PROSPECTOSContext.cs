using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clientes.Models
{
    public partial class PROSPECTOSContext : DbContext
    {
        public PROSPECTOSContext()
        {
        }

        public PROSPECTOSContext(DbContextOptions<PROSPECTOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Prospecto> Prospectos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-SGBH6NAI\\SQLDEV;Database=PROSPECTOS;User Id=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLIENTES");

                entity.Property(e => e.Activo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVO");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CALLE");

                entity.Property(e => e.CodigoPostal).HasColumnName("CODIGO_POSTAL");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COLONIA");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTATUS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRIMER_APELLIDO");

                entity.Property(e => e.Rfc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDO_APELLIDO");

                entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
            });

            modelBuilder.Entity<Prospecto>(entity =>
            {
                entity.ToTable("PROSPECTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVO");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CALLE");

                entity.Property(e => e.CodigoPostal).HasColumnName("CODIGO_POSTAL");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COLONIA");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTATUS");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRIMER_APELLIDO");

                entity.Property(e => e.Rfc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDO_APELLIDO");

                entity.Property(e => e.Telefono).HasColumnName("TELEFONO");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACIONES");

                entity.Property(e => e.NombreArchivo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_ARCHIVO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
