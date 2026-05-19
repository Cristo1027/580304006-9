using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using GestionITM.Domain.Models; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionITM.Infrastructure.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepo;
        private readonly ICursoRepository _cursoRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<MatriculaService> _logger;

        public MatriculaService(
            IMatriculaRepository matriculaRepo,
            ICursoRepository cursoRepo,
            IMapper mapper,
            ILogger<MatriculaService> logger)
        {
            _matriculaRepo = matriculaRepo;
            _cursoRepo = cursoRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MatriculaDto> CrearMatriculaAsync(
            MatriculaCreateDto dto, int estudianteId)
        {
            // FASE A: Verificar que el curso existe
            var curso = await _cursoRepo.ObtenerPorIdAsync(dto.CursoId);
            if (curso == null)
                throw new KeyNotFoundException(
                    $"El curso con ID {dto.CursoId} no existe.");

            // FASE B: REGLA DE NEGOCIO "El Chef" — verificar cupos
            if (curso.CuposDisponibles <= 0)
            {
                _logger.LogWarning(
                    "Matricula rechazada por falta de cupos. " +
                    "EstudianteId: {EstId}, CursoId: {CurId}",
                    estudianteId, dto.CursoId);

                throw new ArgumentException(
                    $"El curso '{curso.Nombre}' no tiene cupos disponibles.");
            }

            // FASE C: Verificar que no esté ya matriculado
            var yaExiste = await _matriculaRepo
                .ExisteMatriculaAsync(estudianteId, dto.CursoId);

            if (yaExiste)
                throw new ArgumentException(
                    $"Ya estás matriculado en el curso '{curso.Nombre}'.");

            // FASE D: Crear y persistir la matrícula
            try
            {
                var matricula = new Matricula
                {
                    EstudianteId = estudianteId,
                    CursoId = dto.CursoId,
                    Periodo = dto.Periodo,
                    Estado = "Activa"
                };

                curso.CuposDisponibles--;
                await _matriculaRepo.AgregarAsync(matricula);

                _logger.LogInformation(
                    "Matricula creada exitosamente. " +
                    "EstudianteId: {EstId}, CursoId: {CurId}, Periodo: {Per}",
                    estudianteId, dto.CursoId, dto.Periodo);

                return _mapper.Map<MatriculaDto>(matricula);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error crítico al guardar la matrícula. EstudianteId: {EstId}",
                    estudianteId);
                throw;
            }
        }

        public async Task<PagedResult<Curso>> ObtenerCursosPaginadosAsync(
            int pageNumber, int pageSize)
        {
            // FASE A: IQueryable
            var consulta = _cursoRepo.ObtenerQueryable()
                .Where(c => c.CuposDisponibles > 0)
                .OrderBy(c => c.Nombre);

            // FASE B: COUNT(*)
            var totalRegistros = await consulta.CountAsync();

            // FASE C: OFFSET/FETCH
            var items = await consulta
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // FASE D: Empaquetar — usando Domain.Models.PagedResult igual que ProfesorService
            return new PagedResult<Curso>
            {
                Items = items,
                TotalRegistros = totalRegistros,
                PaginaActual = pageNumber,
                RegistrosPorPagina = pageSize,
                TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)pageSize)
            };
        }
    }
}