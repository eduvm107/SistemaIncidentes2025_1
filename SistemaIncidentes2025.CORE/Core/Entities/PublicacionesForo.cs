using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class PublicacionesForo
{
    public int Id { get; set; }

    public int? IncidenteId { get; set; }

    public int? UsuarioId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public bool? EsAnonimo { get; set; }

    public int? PublicacionPadreId { get; set; }

    public int? NivelProfundidad { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? Estado { get; set; }

    public bool? Reportado { get; set; }

    public int? NumeroReportes { get; set; }

    public int? NumeroLikes { get; set; }

    public int? NumeroRespuestas { get; set; }

    public virtual Incidentes? Incidente { get; set; }

    public virtual ICollection<PublicacionesForo> InversePublicacionPadre { get; set; } = new List<PublicacionesForo>();

    public virtual PublicacionesForo? PublicacionPadre { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
