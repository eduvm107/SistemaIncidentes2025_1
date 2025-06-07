using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaIncidentes2025.CORE.Core.Entities;

namespace SistemaIncidentes2025.CORE.Infrastructure.Data;

public partial class SistemaIncidentesContext : DbContext
{
    public SistemaIncidentesContext()
    {
    }

    public SistemaIncidentesContext(DbContextOptions<SistemaIncidentesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ColaIncidentes> ColaIncidentes { get; set; }

    public virtual DbSet<ConfiguracionSistema> ConfiguracionSistema { get; set; }

    public virtual DbSet<EstadisticasDiarias> EstadisticasDiarias { get; set; }

    public virtual DbSet<EvidenciasFotograficas> EvidenciasFotograficas { get; set; }

    public virtual DbSet<HistorialNotificaciones> HistorialNotificaciones { get; set; }

    public virtual DbSet<Incidentes> Incidentes { get; set; }

    public virtual DbSet<NumerosEmergencia> NumerosEmergencia { get; set; }

    public virtual DbSet<PublicacionesForo> PublicacionesForo { get; set; }

    public virtual DbSet<TiposIncidente> TiposIncidente { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<VwColaProcesamientoPendiente> VwColaProcesamientoPendiente { get; set; }

    public virtual DbSet<VwDatosMapaCalor> VwDatosMapaCalor { get; set; }

    public virtual DbSet<VwEstadisticasTipoIncidente> VwEstadisticasTipoIncidente { get; set; }

    public virtual DbSet<VwIncidentesMapaCompleto> VwIncidentesMapaCompleto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-F898MU7;Database=SistemaIncidentes;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColaIncidentes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ColaInci__3214EC27DDC4F4ED");

            entity.HasIndex(e => e.EstadoProceso, "IX_ColaIncidentes_EstadoProceso");

            entity.HasIndex(e => e.FechaIngreso, "IX_ColaIncidentes_FechaIngreso");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ErrorMensaje).HasMaxLength(1000);
            entity.Property(e => e.EstadoProceso)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IncidenteId).HasColumnName("IncidenteID");
            entity.Property(e => e.IntentosProceso).HasDefaultValue(0);
            entity.Property(e => e.MaximoIntentos).HasDefaultValue(3);

            entity.HasOne(d => d.Incidente).WithMany(p => p.ColaIncidentes)
                .HasForeignKey(d => d.IncidenteId)
                .HasConstraintName("FK_ColaIncidentes_Incidente");
        });

        modelBuilder.Entity<ConfiguracionSistema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC2788D90408");

            entity.HasIndex(e => e.Clave, "UQ__Configur__E8181E11124BA548").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Clave).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.FechaModificacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModificadoPor).HasMaxLength(100);
            entity.Property(e => e.TipoDato)
                .HasMaxLength(20)
                .HasDefaultValue("STRING");
            entity.Property(e => e.Valor).HasMaxLength(1000);
        });

        modelBuilder.Entity<EstadisticasDiarias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estadist__3214EC2703EF932D");

            entity.HasIndex(e => new { e.Fecha, e.TipoIncidenteId }, "UK_EstadisticasDiarias_Fecha_Tipo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IncidentesVerificados).HasDefaultValue(0);
            entity.Property(e => e.TiempoPromedioRespuesta).HasDefaultValue(0);
            entity.Property(e => e.TipoIncidenteId).HasColumnName("TipoIncidenteID");
            entity.Property(e => e.TotalIncidentes).HasDefaultValue(0);

            entity.HasOne(d => d.TipoIncidente).WithMany(p => p.EstadisticasDiarias)
                .HasForeignKey(d => d.TipoIncidenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstadisticasDiarias_TipoIncidente");
        });

        modelBuilder.Entity<EvidenciasFotograficas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evidenci__3214EC27320EC1C0");

            entity.HasIndex(e => e.EsPortada, "IX_EvidenciasFotograficas_EsPortada");

            entity.HasIndex(e => e.IncidenteId, "IX_EvidenciasFotograficas_Incidente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.EsPortada).HasDefaultValue(false);
            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IncidenteId).HasColumnName("IncidenteID");
            entity.Property(e => e.NombreArchivoOriginal).HasMaxLength(255);
            entity.Property(e => e.NombreArchivoSistema).HasMaxLength(255);
            entity.Property(e => e.RutaArchivo).HasMaxLength(500);
            entity.Property(e => e.TipoArchivo).HasMaxLength(50);
            entity.Property(e => e.Verificado).HasDefaultValue(false);

            entity.HasOne(d => d.Incidente).WithMany(p => p.EvidenciasFotograficas)
                .HasForeignKey(d => d.IncidenteId)
                .HasConstraintName("FK_EvidenciasFotograficas_Incidente");
        });

        modelBuilder.Entity<HistorialNotificaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC27A737C540");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Asunto).HasMaxLength(200);
            entity.Property(e => e.Destinatario).HasMaxLength(200);
            entity.Property(e => e.ErrorMensaje).HasMaxLength(500);
            entity.Property(e => e.EstadoEnvio)
                .HasMaxLength(20)
                .HasDefaultValue("Enviado");
            entity.Property(e => e.FechaEnvio).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IncidenteId).HasColumnName("IncidenteID");
            entity.Property(e => e.Mensaje).HasMaxLength(2000);
            entity.Property(e => e.TipoNotificacion).HasMaxLength(50);

            entity.HasOne(d => d.Incidente).WithMany(p => p.HistorialNotificaciones)
                .HasForeignKey(d => d.IncidenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorialNotificaciones_Incidente");
        });

        modelBuilder.Entity<Incidentes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Incident__3214EC275B4ACEE9");

            entity.ToTable(tb => tb.HasTrigger("tr_Incidentes_ActualizarEstadisticas"));

            entity.HasIndex(e => e.EsAnonimo, "IX_Incidentes_EsAnonimo");

            entity.HasIndex(e => e.Estado, "IX_Incidentes_Estado");

            entity.HasIndex(e => e.FechaIncidente, "IX_Incidentes_FechaIncidente");

            entity.HasIndex(e => e.TipoIncidenteId, "IX_Incidentes_TipoIncidente");

            entity.HasIndex(e => new { e.Latitud, e.Longitud }, "IX_Incidentes_Ubicacion");

            entity.HasIndex(e => e.UsuarioId, "IX_Incidentes_Usuario");

            entity.HasIndex(e => e.NumeroReferencia, "UQ__Incident__1EE916A02273C5F5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasMaxLength(2000);
            entity.Property(e => e.Direccion).HasMaxLength(300);
            entity.Property(e => e.DireccionIp)
                .HasMaxLength(45)
                .HasColumnName("DireccionIP");
            entity.Property(e => e.EsAnonimo).HasDefaultValue(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Reportado");
            entity.Property(e => e.FechaIncidente).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaReporte).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Latitud).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(11, 8)");
            entity.Property(e => e.NotificacionEnviada).HasDefaultValue(false);
            entity.Property(e => e.NumeroReferencia).HasMaxLength(50);
            entity.Property(e => e.Prioridad)
                .HasMaxLength(10)
                .HasDefaultValue("Media");
            entity.Property(e => e.TipoIncidenteId).HasColumnName("TipoIncidenteID");
            entity.Property(e => e.Titulo).HasMaxLength(200);
            entity.Property(e => e.UbicacionGeneradaAuto).HasDefaultValue(true);
            entity.Property(e => e.UserAgent).HasMaxLength(500);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Verificado).HasDefaultValue(false);

            entity.HasOne(d => d.TipoIncidente).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.TipoIncidenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Incidentes_TipoIncidente");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Incidentes_Usuario");
        });

        modelBuilder.Entity<NumerosEmergencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NumerosE__3214EC27C5D534F8");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EsActivo).HasDefaultValue(true);
            entity.Property(e => e.Institucion).HasMaxLength(100);
            entity.Property(e => e.OrdenPrioridad).HasDefaultValue(1);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoIncidenteId).HasColumnName("TipoIncidenteID");

            entity.HasOne(d => d.TipoIncidente).WithMany(p => p.NumerosEmergencia)
                .HasForeignKey(d => d.TipoIncidenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NumerosEmergencia_TipoIncidente");
        });

        modelBuilder.Entity<PublicacionesForo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publicac__3214EC27086AAA77");

            entity.HasIndex(e => e.Estado, "IX_PublicacionesForo_Estado");

            entity.HasIndex(e => e.IncidenteId, "IX_PublicacionesForo_Incidente");

            entity.HasIndex(e => e.PublicacionPadreId, "IX_PublicacionesForo_Padre");

            entity.HasIndex(e => e.UsuarioId, "IX_PublicacionesForo_Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contenido).HasMaxLength(4000);
            entity.Property(e => e.EsAnonimo).HasDefaultValue(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Activo");
            entity.Property(e => e.FechaPublicacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IncidenteId).HasColumnName("IncidenteID");
            entity.Property(e => e.NivelProfundidad).HasDefaultValue(0);
            entity.Property(e => e.NumeroLikes).HasDefaultValue(0);
            entity.Property(e => e.NumeroReportes).HasDefaultValue(0);
            entity.Property(e => e.NumeroRespuestas).HasDefaultValue(0);
            entity.Property(e => e.PublicacionPadreId).HasColumnName("PublicacionPadreID");
            entity.Property(e => e.Reportado).HasDefaultValue(false);
            entity.Property(e => e.Titulo).HasMaxLength(200);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Incidente).WithMany(p => p.PublicacionesForo)
                .HasForeignKey(d => d.IncidenteId)
                .HasConstraintName("FK_PublicacionesForo_Incidente");

            entity.HasOne(d => d.PublicacionPadre).WithMany(p => p.InversePublicacionPadre)
                .HasForeignKey(d => d.PublicacionPadreId)
                .HasConstraintName("FK_PublicacionesForo_Padre");

            entity.HasOne(d => d.Usuario).WithMany(p => p.PublicacionesForo)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_PublicacionesForo_Usuario");
        });

        modelBuilder.Entity<TiposIncidente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TiposInc__3214EC2796BC27DC");

            entity.HasIndex(e => e.Nombre, "UQ__TiposInc__75E3EFCFD2C7DBC7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Color).HasMaxLength(7);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.EsEmergencia).HasDefaultValue(false);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Icono).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27738FA433");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053486EFF164").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<VwColaProcesamientoPendiente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ColaProcesamientoPendiente");

            entity.Property(e => e.EstadoProceso).HasMaxLength(20);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IncidenteId).HasColumnName("IncidenteID");
            entity.Property(e => e.NumeroReferencia).HasMaxLength(50);
            entity.Property(e => e.TipoIncidente).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(200);
        });

        modelBuilder.Entity<VwDatosMapaCalor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DatosMapaCalor");

            entity.Property(e => e.Color).HasMaxLength(7);
            entity.Property(e => e.Latitud).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(11, 8)");
            entity.Property(e => e.TipoIncidente).HasMaxLength(50);
        });

        modelBuilder.Entity<VwEstadisticasTipoIncidente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EstadisticasTipoIncidente");

            entity.Property(e => e.Color).HasMaxLength(7);
            entity.Property(e => e.Icono).HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TipoIncidente).HasMaxLength(50);
        });

        modelBuilder.Entity<VwIncidentesMapaCompleto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_IncidentesMapaCompleto");

            entity.Property(e => e.ColorTipo).HasMaxLength(7);
            entity.Property(e => e.Descripcion).HasMaxLength(2000);
            entity.Property(e => e.Direccion).HasMaxLength(300);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FotoPortada).HasMaxLength(500);
            entity.Property(e => e.IconoTipo).HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Latitud).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(11, 8)");
            entity.Property(e => e.NumeroReferencia).HasMaxLength(50);
            entity.Property(e => e.Prioridad).HasMaxLength(10);
            entity.Property(e => e.Reportante).HasMaxLength(100);
            entity.Property(e => e.TipoIncidente).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(200);
        });
        modelBuilder.HasSequence("seq_NumeroReferencia")
            .HasMin(1L)
            .HasMax(999999L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
