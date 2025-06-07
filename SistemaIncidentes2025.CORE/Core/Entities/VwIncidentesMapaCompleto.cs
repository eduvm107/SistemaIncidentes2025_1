using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class VwIncidentesMapaCompleto
{
    public int Id { get; set; }

    public string? NumeroReferencia { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string TipoIncidente { get; set; } = null!;

    public string? ColorTipo { get; set; }

    public string? IconoTipo { get; set; }

    public bool? EsEmergencia { get; set; }

    public string? Reportante { get; set; }

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public string? Direccion { get; set; }

    public DateTime FechaIncidente { get; set; }

    public DateTime? FechaReporte { get; set; }

    public string? Estado { get; set; }

    public string? Prioridad { get; set; }

    public bool? Verificado { get; set; }

    public bool? NotificacionEnviada { get; set; }

    public int? NumeroFotos { get; set; }

    public string? FotoPortada { get; set; }
}
