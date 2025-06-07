using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class VwDatosMapaCalor
{
    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public int? Intensidad { get; set; }

    public string TipoIncidente { get; set; } = null!;

    public string? Color { get; set; }
}
