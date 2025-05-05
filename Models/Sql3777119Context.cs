using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PediatriaABC.Models;

public partial class Sql3777119Context : DbContext
{
    public Sql3777119Context()
    {
    }

    public Sql3777119Context(DbContextOptions<Sql3777119Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=sql3.freesqldatabase.com;port=3306;database=sql3777119;user=sql3777119;password=MmMVq6YsJX", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.54-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasDefaultValueSql("'Desconocido'")
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimientoHijo).HasColumnName("fechaNacimientoHijo");
            entity.Property(e => e.FechaRegistro).HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreHijo)
                .HasMaxLength(255)
                .HasColumnName("nombreHijo");
            entity.Property(e => e.NombreTutor)
                .HasMaxLength(255)
                .HasColumnName("nombreTutor");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
