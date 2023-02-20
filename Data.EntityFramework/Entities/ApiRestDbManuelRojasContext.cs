﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.EntityFramework.Entities;

public partial class ApiRestDbManuelRojasContext : DbContext
{
    public ApiRestDbManuelRojasContext()
    {
    }

    public ApiRestDbManuelRojasContext(DbContextOptions<ApiRestDbManuelRojasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<ParTipoCuentum> ParTipoCuenta { get; set; }

    public virtual DbSet<ParTipoGenero> ParTipoGeneros { get; set; }

    public virtual DbSet<ParTipoIdentificacion> ParTipoIdentificacions { get; set; }

    public virtual DbSet<ParTipoMovimiento> ParTipoMovimientos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ASUS_TUF_MR\\SQLEXPRESS; Database=ApiRestDB_ManuelRojas; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D59466423EE4AAEE");

            entity.Property(e => e.Contrasenia).HasMaxLength(1000);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdPersona");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuentas__D41FD706A48B5A4D");

            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Saldo).HasColumnType("decimal(12, 3)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdCliente");

            entity.HasOne(d => d.IdTipoCuentaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdTipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdTipoCuenta");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__Movimien__881A6AE0077CAEAD");

            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");
            entity.Property(e => e.Saldo).HasColumnType("decimal(12, 5)");
            entity.Property(e => e.Valor).HasColumnType("decimal(12, 3)");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdCuenta");

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdTipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdTipoMovimiento");
        });

        modelBuilder.Entity<ParTipoCuentum>(entity =>
        {
            entity.HasKey(e => e.IdTipoCuenta).HasName("PK__ParTipoC__9CCA285056143CE7");

            entity.Property(e => e.NombreTipoCuenta)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ParTipoGenero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__ParTipoG__0F8349883110BA4C");

            entity.ToTable("ParTipoGenero");

            entity.Property(e => e.NombreTipoGenero)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ParTipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoIdentificacion).HasName("PK__ParTipoI__F521C6A856C07025");

            entity.ToTable("ParTipoIdentificacion");

            entity.Property(e => e.NombreTipoIdentificacion)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ParTipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoMovimiento).HasName("PK__ParTipoM__820D7FC25EFE9CDA");

            entity.ToTable("ParTipoMovimiento");

            entity.Property(e => e.NombreTipoMovimiento)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Personas__2EC8D2ACFBC82BC2");

            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Edad)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdTipoGenero");

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdTipoIdentificacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
