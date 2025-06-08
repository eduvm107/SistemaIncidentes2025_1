using SistemaIncidentes2025.CORE.Core.DTOs;
using SistemaIncidentes2025.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIncidentes2025.CORE.Core.Services
{
    public class ContactoEmergenciaService : IContactoEmergenciaService
    {
        private readonly IContactoEmergenciaRepository _repo;
        public ContactoEmergenciaService(IContactoEmergenciaRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<EmergenciaContactoDto>> ObtenerContactosAsync()
        {
            var contactos = await _repo.GetAllAsync();
            return contactos.Select(c => new EmergenciaContactoDto
            {
                Id = c.Id,
                Institucion = c.Institucion,
                Telefono = c.Telefono,
                Email = c.Email,
                TipoIncidenteId = c.TipoIncidenteId,
                TipoIncidenteNombre = c.TipoIncidente?.Nombre,
                OrdenPrioridad = c.OrdenPrioridad
            }).ToList();
        }
    }
}
