using AutoMapper;
using Data.Entities;

namespace API.DTOs.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<MedicoDTO,Medico>().ReverseMap();
            CreateMap<EspecialidadeDTO,Especialidade>().ReverseMap();
        }
    }
}
