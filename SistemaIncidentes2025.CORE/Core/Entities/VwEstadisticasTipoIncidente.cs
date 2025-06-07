using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class VwEstadisticasTipoIncidente
{
    public int Id { get; set; }

    public string TipoIncidente { get; set; } = null!;

    public string? Color { get; set; }

    public string? Icono { get; set; }

    public int? TotalIncidentes { get; set; }

    public int? Reportados { get; set; }

    public int? Procesando { get; set; }

    public int? Notificados { get; set; }

    public int? Resueltos { get; set; }

    public int? Verificados { get; set; }

    public int? UltimoDia { get; set; }

    public int? UltimaSemana { get; set; }

    public int? UltimoMes { get; set; }
}
