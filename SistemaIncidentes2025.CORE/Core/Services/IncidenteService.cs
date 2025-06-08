using SistemaIncidentes2025.CORE.Core.DTOs;
using SistemaIncidentes2025.CORE.Core.Entities;
using SistemaIncidentes2025.CORE.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIncidentes2025.CORE.Core.Services
{
    public class IncidenteService : IIncidenteService
    {
        private readonly IIncidenteRepository _incidenteRepository;
        private readonly ITipoIncidenteRepository _tipoIncidenteRepository;
        public IncidenteService(IIncidenteRepository incidenteRepository, ITipoIncidenteRepository tipoIncidenteRepository)
        {
            _incidenteRepository = incidenteRepository;
            _tipoIncidenteRepository = tipoIncidenteRepository;
        }

        public async Task<IncidenteDto> CrearIncidenteAsync(IncidenteCreateDto dto)
        {
            var incidente = new Incidentes
            {
                TipoIncidenteId = dto.TipoIncidenteId,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                EsAnonimo = dto.EsAnonimo ?? false,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                Direccion = dto.Direccion,
                Prioridad = dto.Prioridad ?? "Media",
                Estado = "Aprobado", // Cambiado para que todos los incidentes sean visibles automáticamente
                FechaIncidente = DateTime.UtcNow
            };
            incidente = await _incidenteRepository.AddAsync(incidente);
            var tipo = await _tipoIncidenteRepository.GetByIdAsync(incidente.TipoIncidenteId);
            return new IncidenteDto
            {
                Id = incidente.Id,
                TipoIncidenteId = incidente.TipoIncidenteId,
                Titulo = incidente.Titulo,
                Descripcion = incidente.Descripcion,
                EsAnonimo = incidente.EsAnonimo,
                Latitud = incidente.Latitud,
                Longitud = incidente.Longitud,
                Direccion = incidente.Direccion,
                FechaIncidente = incidente.FechaIncidente,
                Estado = incidente.Estado,
                Prioridad = incidente.Prioridad,
                NumeroReferencia = incidente.NumeroReferencia,
                TipoIncidenteNombre = tipo?.Nombre ?? ""
            };
        }

        public async Task<List<IncidenteDto>> ObtenerIncidentesAprobadosAsync()
        {
            // Ahora devuelve todos los incidentes, no solo los aprobados
            var incidentes = await _incidenteRepository.GetAllAsync();
            return incidentes.Select(i => new IncidenteDto
            {
                Id = i.Id,
                TipoIncidenteId = i.TipoIncidenteId,
                Titulo = i.Titulo,
                Descripcion = i.Descripcion,
                EsAnonimo = i.EsAnonimo,
                Latitud = i.Latitud,
                Longitud = i.Longitud,
                Direccion = i.Direccion,
                FechaIncidente = i.FechaIncidente,
                Estado = i.Estado,
                Prioridad = i.Prioridad,
                NumeroReferencia = i.NumeroReferencia,
                TipoIncidenteNombre = i.TipoIncidente?.Nombre ?? ""
            }).ToList();
        }

        public async Task<List<IncidenteMapaDto>> ObtenerIncidentesMapaAsync()
        {
            // Ahora devuelve todos los incidentes, no solo los aprobados
            var incidentes = await _incidenteRepository.GetAllAsync();
            return incidentes.Select(i => new IncidenteMapaDto
            {
                Id = i.Id,
                Latitud = i.Latitud,
                Longitud = i.Longitud,
                Estado = i.Estado,
                Prioridad = i.Prioridad,
                TipoIncidenteNombre = i.TipoIncidente?.Nombre ?? ""
            }).ToList();
        }
    }

    public class TipoIncidenteService : ITipoIncidenteService
    {
        private readonly ITipoIncidenteRepository _repo;
        public TipoIncidenteService(ITipoIncidenteRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<TipoIncidenteDto>> ObtenerTiposAsync()
        {
            var tipos = await _repo.GetAllAsync();
            return tipos.Select(t => new TipoIncidenteDto
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion
            }).ToList();
        }
    }
}
