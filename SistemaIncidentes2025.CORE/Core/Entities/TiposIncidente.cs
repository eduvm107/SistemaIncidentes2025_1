using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class TiposIncidente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Color { get; set; }

    public string? Icono { get; set; }

    public bool? EsEmergencia { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<EstadisticasDiarias> EstadisticasDiarias { get; set; } = new List<EstadisticasDiarias>();

    public virtual ICollection<Incidentes> Incidentes { get; set; } = new List<Incidentes>();

    public virtual ICollection<NumerosEmergencia> NumerosEmergencia { get; set; } = new List<NumerosEmergencia>();
}
