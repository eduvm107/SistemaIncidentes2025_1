using SistemaIncidentes2025.CORE.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIncidentes2025.CORE.Core.Interfaces
{
    public interface IIncidenteRepository
    {
        Task<Incidentes> AddAsync(Incidentes incidente);
        Task<List<Incidentes>> GetAprobadosAsync();
        Task<List<Incidentes>> GetAllAsync();
        Task<Incidentes?> GetByIdAsync(int id);
    }

    public interface ITipoIncidenteRepository
    {
        Task<List<TiposIncidente>> GetAllAsync();
        Task<TiposIncidente?> GetByIdAsync(int id);
    }
}
