using AutoMapper; 
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _repository;
        private readonly IMapper _mapper; 

        public ProfesorService(IProfesorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfesorDto>> ObtenerTodosAsync()
        {
            var profesores = await _repository.GetAllAsync();
            // Uso de AutoMapper para colecciones
            return _mapper.Map<IEnumerable<ProfesorDto>>(profesores);
        }

        public async Task<ProfesorDto> CrearProfesorAsync(ProfesorCreateDto dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.Especialidad))
                throw new Exception("La especialidad no puede ser vacía.");

            
            if (dto.Especialidad.Equals("Arquitectura", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Perfil Senior Detectado");

            
            if (await _repository.EmailExistsAsync(dto.Email))
                throw new Exception("El Email ya está registrado en la base de datos.");

        
            if (dto.Nombre.ToLower() == "error")
                throw new Exception("Error de prueba");

            
            var nuevoProfesor = _mapper.Map<Profesor>(dto);

            await _repository.AddAsync(nuevoProfesor);

            return _mapper.Map<ProfesorDto>(nuevoProfesor);
        }
    }
}
