using SistemaIncidentes2025.CORE.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIncidentes2025.CORE.Core.Interfaces
{
    public interface IIncidenteService
    {
        Task<IncidenteDto> CrearIncidenteAsync(IncidenteCreateDto dto);
        Task<List<IncidenteDto>> ObtenerIncidentesAprobadosAsync();
        Task<List<IncidenteMapaDto>> ObtenerIncidentesMapaAsync();
    }

    public interface ITipoIncidenteService
    {
        Task<List<TipoIncidenteDto>> ObtenerTiposAsync();
    }
}
