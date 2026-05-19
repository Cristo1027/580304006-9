using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.API.Mappings
{
    // Configura los mapeos entre entidades y DTOs
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Estudiante, EstudianteDto>();
            CreateMap<EstudianteCreateDto, Estudiante>();

            // Mapeos para Profesor
            CreateMap<Profesor, ProfesorDto>();
            CreateMap<ProfesorCreateDto, Profesor>();

            //mapeos para Matriculas
            CreateMap<Matricula, MatriculaDto>();
            CreateMap<MatriculaCreateDto, Matricula>();
        }
    }
}
