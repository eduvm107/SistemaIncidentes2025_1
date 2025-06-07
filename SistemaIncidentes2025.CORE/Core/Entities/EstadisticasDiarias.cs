using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class EstadisticasDiarias
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int TipoIncidenteId { get; set; }

    public int? TotalIncidentes { get; set; }

    public int? IncidentesVerificados { get; set; }

    public int? TiempoPromedioRespuesta { get; set; }

    public virtual TiposIncidente TipoIncidente { get; set; } = null!;
}
