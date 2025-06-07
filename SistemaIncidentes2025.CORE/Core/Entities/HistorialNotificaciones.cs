using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class HistorialNotificaciones
{
    public int Id { get; set; }

    public int IncidenteId { get; set; }

    public string? TipoNotificacion { get; set; }

    public string? Destinatario { get; set; }

    public string? Asunto { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public string? EstadoEnvio { get; set; }

    public string? ErrorMensaje { get; set; }

    public virtual Incidentes Incidente { get; set; } = null!;
}
