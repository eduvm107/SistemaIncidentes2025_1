using System;
using System.Collections.Generic;

namespace SistemaIncidentes2025.CORE.Core.Entities;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Incidentes> Incidentes { get; set; } = new List<Incidentes>();

    public virtual ICollection<PublicacionesForo> PublicacionesForo { get; set; } = new List<PublicacionesForo>();
}
