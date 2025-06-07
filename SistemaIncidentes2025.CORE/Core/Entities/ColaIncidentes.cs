using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class ColaIncidentes
{
    public int Id { get; set; }

    public int IncidenteId { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? EstadoProceso { get; set; }

    public int? IntentosProceso { get; set; }

    public int? MaximoIntentos { get; set; }

    public DateTime? FechaProceso { get; set; }

    public DateTime? FechaCompletado { get; set; }

    public string? ErrorMensaje { get; set; }

    public virtual Incidentes Incidente { get; set; } = null!;
}
