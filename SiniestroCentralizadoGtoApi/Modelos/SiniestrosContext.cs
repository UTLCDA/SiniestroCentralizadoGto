using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SiniestroCentralizadoGtoApi.Modelos;

public partial class SiniestrosContext : DbContext
{
    public SiniestrosContext()
    {
    }

    public SiniestrosContext(DbContextOptions<SiniestrosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ajustador> Ajustador { get; set; }

    public virtual DbSet<Contratante> Contratante { get; set; }

    public virtual DbSet<Periodicidad> Periodicidad { get; set; }

    public virtual DbSet<Poliza> Poliza { get; set; }

    public virtual DbSet<Reporte> Reporte { get; set; }

    public virtual DbSet<SeguimientoSiniestro> SeguimientoSiniestro { get; set; }

    public virtual DbSet<SolicitudContratante> SolicitudContratante { get; set; }

    public virtual DbSet<Sucursal> Sucursal { get; set; }

    public virtual DbSet<TipoPersona> TipoPersona { get; set; }

    public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Vehiculo> Vehiculo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ajustador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ajustado__3214EC074C866D49");

            entity.ToTable("Ajustador");

            entity.HasIndex(e => e.NumeroEmpleado, "UQ__Ajustado__44F848FD364D9CF8").IsUnique();

            entity.HasIndex(e => e.Curp, "UQ__Ajustado__AFAC52E5994AEEBA").IsUnique();

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Carro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Colonia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Coordenadas)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CP");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Matricula)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NumeroEmpleado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RFC");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contratante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contrata__3214EC07E9004075");

            entity.ToTable("Contratante");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Banco)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CuentaBancaria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RFC");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Periodicidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Periodic__3214EC073FC67045");

            entity.ToTable("Periodicidad");

            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Poliza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Poliza__3214EC078AAE9DF4");

            entity.ToTable("Poliza");

            entity.HasIndex(e => e.NumeroPoliza, "UQ__Poliza__38B31021193B6209").IsUnique();

            entity.Property(e => e.Beneficiario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LineaNegocio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroPoliza)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Contratante).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.ContratanteId)
                .HasConstraintName("FK_Poliza_Contratante");

            entity.HasOne(d => d.OficinaEmision).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.OficinaEmisionId)
                .HasConstraintName("FK_Poliza_Sucursal");

            entity.HasOne(d => d.Periodicidad).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.PeriodicidadId)
                .HasConstraintName("FK_Poliza_Periodicidad");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK_Poliza_Vehiculo");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reporte__3214EC07FF5ADEB9");

            entity.ToTable("Reporte");

            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionSiniestro).HasColumnType("text");
            entity.Property(e => e.LugarSiniestroCoordenadas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LugarSiniestro_Coordenadas");
            entity.Property(e => e.LugarSiniestroDireccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LugarSiniestro_Direccion");
            entity.Property(e => e.ObservacionesAjustador).HasColumnType("text");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Ajustador).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.AjustadorId)
                .HasConstraintName("FK_Reporte_Ajustador");

            entity.HasOne(d => d.NombreReporte).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.NombreReporteId)
                .HasConstraintName("FK_Reporte_TipoPersona");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK_Reporte_Vehiculo");
        });

        modelBuilder.Entity<SeguimientoSiniestro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seguimie__3214EC07506E599C");

            entity.ToTable("SeguimientoSiniestro");

            entity.Property(e => e.Comentarios).HasColumnType("text");
            entity.Property(e => e.NombreAjustador)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NumeroPolizaAfectado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.NumeroAjustadorAltaNavigation).WithMany(p => p.SeguimientoSiniestros)
                .HasForeignKey(d => d.NumeroAjustadorAlta)
                .HasConstraintName("FK_Seguimiento_Ajustador");

            entity.HasOne(d => d.NumeroSiniestro).WithMany(p => p.SeguimientoSiniestros)
                .HasForeignKey(d => d.NumeroSiniestroId)
                .HasConstraintName("FK_Seguimiento_Reporte");
        });

        modelBuilder.Entity<SolicitudContratante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicitu__3214EC07778F4033");

            entity.ToTable("SolicitudContratante");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionAccidente)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.LugarCoordenadas)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LugarSiniestroDetalle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumeroPoliza)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sucursal__3214EC07D297F31F");

            entity.ToTable("Sucursal");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPers__3214EC07D52EF9B1");

            entity.ToTable("TipoPersona");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipoVehiculo).HasName("PK__TipoVehi__DC20741EF2F6BE4A");

            entity.ToTable("TipoVehiculo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE21F7FE674");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Localizacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroEmpleado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UltimoAcceso).HasColumnType("datetime");

            entity.HasOne(d => d.NumeroEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasPrincipalKey(p => p.NumeroEmpleado)
                .HasForeignKey(d => d.NumeroEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Ajustador");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3214EC07227FF215");

            entity.ToTable("Vehiculo");

            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSerie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Placas)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoVehiculoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdTipoVehiculo)
                .HasConstraintName("FK_Vehiculo_TipoVehiculo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
