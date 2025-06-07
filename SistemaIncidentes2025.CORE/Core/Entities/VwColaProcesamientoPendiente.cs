using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class VwColaProcesamientoPendiente
{
    public int Id { get; set; }

    public int IncidenteId { get; set; }

    public string? NumeroReferencia { get; set; }

    public string Titulo { get; set; } = null!;

    public string TipoIncidente { get; set; } = null!;

    public bool? EsEmergencia { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? EstadoProceso { get; set; }

    public int? IntentosProceso { get; set; }

    public int? MaximoIntentos { get; set; }

    public int? MinutosEspera { get; set; }
}
