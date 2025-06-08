using SistemaIncidentes2025.CORE.Core.Entities;
using SistemaIncidentes2025.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaIncidentes2025.CORE.Core.Interfaces;

namespace SistemaIncidentes2025.CORE.Infrastructure.Repositories
{
    public class IncidenteRepository : IIncidenteRepository
    {
        private readonly SistemaIncidentesContext _context;
        public IncidenteRepository(SistemaIncidentesContext context)
        {
            _context = context;
        }

        public async Task<Incidentes> AddAsync(Incidentes incidente)
        {
            _context.Incidentes.Add(incidente);
            await _context.SaveChangesAsync();
            return incidente;
        }

        public async Task<List<Incidentes>> GetAprobadosAsync()
        {
            return await _context.Incidentes
                .Include(i => i.TipoIncidente)
                .Where(i => i.Estado == "Aprobado")
                .ToListAsync();
        }

        public async Task<List<Incidentes>> GetAllAsync()
        {
            return await _context.Incidentes.Include(i => i.TipoIncidente).ToListAsync();
        }

        public async Task<Incidentes?> GetByIdAsync(int id)
        {
            return await _context.Incidentes.Include(i => i.TipoIncidente).FirstOrDefaultAsync(i => i.Id == id);
        }
    }

    public class TipoIncidenteRepository : ITipoIncidenteRepository
    {
        private readonly SistemaIncidentesContext _context;
        public TipoIncidenteRepository(SistemaIncidentesContext context)
        {
            _context = context;
        }

        public async Task<List<TiposIncidente>> GetAllAsync()
        {
            return await _context.TiposIncidente.ToListAsync();
        }

        public async Task<TiposIncidente?> GetByIdAsync(int id)
        {
            return await _context.TiposIncidente.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
