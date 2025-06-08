using Microsoft.AspNetCore.Mvc;
using SistemaIncidentes2025.CORE.Core.DTOs;
using SistemaIncidentes2025.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIncidentes2025.Controllers
{
    // Controlador para contactos de emergencia
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosEmergenciaController : ControllerBase
    {
        private readonly IContactoEmergenciaService _service;
        public ContactosEmergenciaController(IContactoEmergenciaService service)
        {
            _service = service;
        }

        // Endpoint para obtener todos los contactos de emergencia activos
        [HttpGet]
        public async Task<ActionResult<List<EmergenciaContactoDto>>> Get()
        {
            var result = await _service.ObtenerContactosAsync();
            return Ok(result);
        }
    }
}
