using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class Incidentes
{
    public int Id { get; set; }

    public int TipoIncidenteId { get; set; }

    public int? UsuarioId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool? EsAnonimo { get; set; }

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public string? Direccion { get; set; }

    public bool? UbicacionGeneradaAuto { get; set; }

    public DateTime FechaIncidente { get; set; }

    public DateTime? FechaReporte { get; set; }

    public string? Estado { get; set; }

    public string? Prioridad { get; set; }

    public string? NumeroReferencia { get; set; }

    public bool? Verificado { get; set; }

    public DateTime? FechaVerificacion { get; set; }

    public bool? NotificacionEnviada { get; set; }

    public DateTime? FechaNotificacion { get; set; }

    public string? DireccionIp { get; set; }

    public string? UserAgent { get; set; }

    public virtual ICollection<ColaIncidentes> ColaIncidentes { get; set; } = new List<ColaIncidentes>();

    public virtual ICollection<EvidenciasFotograficas> EvidenciasFotograficas { get; set; } = new List<EvidenciasFotograficas>();

    public virtual ICollection<HistorialNotificaciones> HistorialNotificaciones { get; set; } = new List<HistorialNotificaciones>();

    public virtual ICollection<PublicacionesForo> PublicacionesForo { get; set; } = new List<PublicacionesForo>();

    public virtual TiposIncidente TipoIncidente { get; set; } = null!;

    public virtual Usuarios? Usuario { get; set; }
}
