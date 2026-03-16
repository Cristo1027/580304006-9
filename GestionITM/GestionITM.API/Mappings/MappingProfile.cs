using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Estudiante, EstudianteDto>();
            CreateMap<EstudianteCreateDto, Estudiante>();

            

          
            CreateMap<Profesor, ProfesorDto>();

           
            CreateMap<ProfesorCreateDto, Profesor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.FechaContratacion, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}