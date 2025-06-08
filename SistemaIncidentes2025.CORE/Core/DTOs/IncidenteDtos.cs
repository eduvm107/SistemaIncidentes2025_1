namespace SistemaIncidentes2025.CORE.Core.DTOs
{
    public class IncidenteCreateDto
    {
        public int TipoIncidenteId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool? EsAnonimo { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string? Direccion { get; set; }
        public string? Prioridad { get; set; }
    }

    public class IncidenteDto
    {
        public int Id { get; set; }
        public int TipoIncidenteId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool? EsAnonimo { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaIncidente { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public string? NumeroReferencia { get; set; }
        public string TipoIncidenteNombre { get; set; } = null!;
    }

    public class IncidenteMapaDto
    {
        public int Id { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public string TipoIncidenteNombre { get; set; } = null!;
    }

    public class TipoIncidenteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }

    public class EmergenciaContactoDto
    {
        public int Id { get; set; }
        public string Institucion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Email { get; set; }
        public int TipoIncidenteId { get; set; }
        public string? TipoIncidenteNombre { get; set; }
        public int? OrdenPrioridad { get; set; }
    }
}
