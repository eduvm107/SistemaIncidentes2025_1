using Microsoft.AspNetCore.Mvc;
using SistemaIncidentes2025.CORE.Core.DTOs;
using SistemaIncidentes2025.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIncidentes2025.Controllers
{
    // Controlador para tipos de incidente
    [ApiController]
    [Route("api/[controller]")]
    public class TiposIncidenteController : ControllerBase
    {
        private readonly ITipoIncidenteService _service;
        public TiposIncidenteController(ITipoIncidenteService service)
        {
            _service = service;
        }

        // Endpoint para obtener todos los tipos de incidente
        [HttpGet]
        public async Task<ActionResult<List<TipoIncidenteDto>>> Get()
        {
            var result = await _service.ObtenerTiposAsync();
            return Ok(result);
        }
    }
}
