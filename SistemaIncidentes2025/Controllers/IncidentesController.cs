using Microsoft.AspNetCore.Mvc;
using SistemaIncidentes2025.CORE.Core.DTOs;
using SistemaIncidentes2025.CORE.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace SistemaIncidentes2025.Controllers
{
    // Controlador para la gesti�n de incidentes
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentesController : ControllerBase
    {
        // Servicio de incidentes inyectado por dependencia
        private readonly IIncidenteService _incidenteService;
        public IncidentesController(IIncidenteService incidenteService)
        {
            _incidenteService = incidenteService;
        }

        // Endpoint para crear un nuevo incidente (JSON)
        [HttpPost]
        public async Task<ActionResult<IncidenteDto>> Crear([FromBody] IncidenteCreateDto dto)
        {
            var result = await _incidenteService.CrearIncidenteAsync(dto);
            return CreatedAtAction(nameof(Crear), new { id = result.Id }, result);
        }

        // Endpoint para crear un nuevo incidente con foto (multipart/form-data)
        [HttpPost("con-foto")]
        public async Task<ActionResult<IncidenteDto>> CrearConFoto([FromForm] IncidenteCreateDto dto, IFormFile? foto)
        {
            // Aqu� deber�as guardar la foto en disco o almacenamiento y guardar la URL en la base de datos
            // Por simplicidad, solo se simula el guardado y se pasa la URL como string
            string? fotoUrl = null;
            if (foto != null && foto.Length > 0)
            {
                // Simulaci�n: en producci�n, guardar el archivo y obtener la URL
                fotoUrl = $"/uploads/{Guid.NewGuid()}_{foto.FileName}";
                // Aqu� deber�as guardar el archivo f�sicamente
            }
            // Puedes extender el DTO y servicio para aceptar fotoUrl
            var result = await _incidenteService.CrearIncidenteAsync(dto); // Extiende l�gica si quieres guardar la URL
            return CreatedAtAction(nameof(CrearConFoto), new { id = result.Id }, result);
        }

        // Endpoint para obtener la lista de incidentes aprobados
        [HttpGet]
        public async Task<ActionResult<List<IncidenteDto>>> GetAprobados()
        {
            var result = await _incidenteService.ObtenerIncidentesAprobadosAsync();
            return Ok(result);
        }

        // Endpoint para obtener los incidentes aprobados con coordenadas para el mapa
        [HttpGet("mapa")]
        public async Task<ActionResult<List<IncidenteMapaDto>>> GetMapa()
        {
            var result = await _incidenteService.ObtenerIncidentesMapaAsync();
            return Ok(result);
        }
    }
}
