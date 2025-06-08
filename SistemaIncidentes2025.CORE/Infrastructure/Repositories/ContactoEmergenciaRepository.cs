using SistemaIncidentes2025.CORE.Core.Entities;
using SistemaIncidentes2025.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaIncidentes2025.CORE.Core.Interfaces;

namespace SistemaIncidentes2025.CORE.Infrastructure.Repositories
{
    public class ContactoEmergenciaRepository : IContactoEmergenciaRepository
    {
        private readonly SistemaIncidentesContext _context;
        public ContactoEmergenciaRepository(SistemaIncidentesContext context)
        {
            _context = context;
        }
        public async Task<List<NumerosEmergencia>> GetAllAsync()
        {
            return await _context.NumerosEmergencia.Include(x => x.TipoIncidente).Where(x => x.EsActivo == true).ToListAsync();
        }
    }
}
