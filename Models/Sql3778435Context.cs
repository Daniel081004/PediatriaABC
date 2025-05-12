using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PediatriaABC.Models;

public partial class Sql3778435Context : DbContext
{
    public Sql3778435Context()
    {
    }

    public Sql3778435Context(DbContextOptions<Sql3778435Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("user=sql3778435;password=dv9u1kGCXC;server=sql3.freesqldatabase.com;database=sql3778435;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.54-mysql"));

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
