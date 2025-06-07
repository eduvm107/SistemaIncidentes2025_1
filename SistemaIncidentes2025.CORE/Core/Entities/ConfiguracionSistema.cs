using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class ConfiguracionSistema
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string? Valor { get; set; }

    public string? Descripcion { get; set; }

    public string? TipoDato { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? ModificadoPor { get; set; }
}
