using SistemaIncidentes2025.CORE.Core.DTOs;
using SistemaIncidentes2025.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIncidentes2025.CORE.Core.Interfaces
{
    public interface IContactoEmergenciaRepository
    {
        Task<List<NumerosEmergencia>> GetAllAsync();
    }

    public interface IContactoEmergenciaService
    {
        Task<List<EmergenciaContactoDto>> ObtenerContactosAsync();
    }
}
