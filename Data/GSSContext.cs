using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AlquilerGSS.Models
{
    public partial class GSSContext : DbContext
    {
        //public GSSContext()
        //{
        //}

        public GSSContext(DbContextOptions<GSSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquilers { get; set; }
        public virtual DbSet<Carro> Carros { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=GSS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.Idalquiler);

                entity.ToTable("alquiler");

                entity.Property(e => e.Idalquiler).HasColumnName("idalquiler");

                entity.Property(e => e.Abonoinicial)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("abonoinicial");

                entity.Property(e => e.Devuelto).HasColumnName("devuelto");

                entity.Property(e => e.Dias)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("dias");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idcarro).HasColumnName("idcarro");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => e.Idcarro);

                entity.ToTable("carro");

                entity.HasIndex(e => e.Placa, "UC_placa")
                    .IsUnique();

                entity.Property(e => e.Idcarro).HasColumnName("idcarro");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("costo");

                entity.Property(e => e.Disponible)
                    .IsRequired()
                    .HasColumnName("disponible")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("placa");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.ToTable("cliente");

                entity.HasIndex(e => e.Cedula, "UC_cedula")
                    .IsUnique();

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Cedula)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("cedula");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono1)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("telefono2");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.Idpago);

                entity.ToTable("pago");

                entity.Property(e => e.Idpago).HasColumnName("idpago");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idalquiler).HasColumnName("idalquiler");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("valor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
