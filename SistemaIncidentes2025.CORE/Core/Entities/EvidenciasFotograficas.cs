using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class EvidenciasFotograficas
{
    public int Id { get; set; }

    public int IncidenteId { get; set; }

    public string NombreArchivoOriginal { get; set; } = null!;

    public string NombreArchivoSistema { get; set; } = null!;

    public string RutaArchivo { get; set; } = null!;

    public string? TipoArchivo { get; set; }

    public long? TamanoArchivo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaSubida { get; set; }

    public bool? EsPortada { get; set; }

    public bool? Verificado { get; set; }

    public virtual Incidentes Incidente { get; set; } = null!;
}
