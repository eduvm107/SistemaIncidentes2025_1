using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class NumerosEmergencia
{
    public int Id { get; set; }

    public int TipoIncidenteId { get; set; }

    public string Institucion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Email { get; set; }

    public bool? EsActivo { get; set; }

    public int? OrdenPrioridad { get; set; }

    public virtual TiposIncidente TipoIncidente { get; set; } = null!;
}
