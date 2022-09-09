using Application.Futures.ProgrammingLanguages.Commands.CreateProgrammingLanguages;
using Application.Futures.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Futures.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Futures.ProgrammingLanguages.Dtos;
using Application.Futures.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Futures.ProgrammingLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

        CreateMap<IPaginate<ProgrammingLanguage>,ProgrammingLanguageListModel>().ReverseMap();

        CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();

        CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
        CreateMap<DeletedProgrammingLanguageDto,ProgrammingLanguage >().ReverseMap();

    }
}