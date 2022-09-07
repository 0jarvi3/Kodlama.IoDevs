using Application.Futures.ProgrammingLanguages.Commands.CreateProgrammingLanguages;
using Application.Futures.ProgrammingLanguages.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Futures.ProgrammingLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
    }
}