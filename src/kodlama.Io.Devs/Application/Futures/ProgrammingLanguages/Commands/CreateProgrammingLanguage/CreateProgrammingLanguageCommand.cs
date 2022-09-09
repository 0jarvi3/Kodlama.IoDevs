using Application.Futures.ProgrammingLanguages.Dtos;
using Application.Futures.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Futures.ProgrammingLanguages.Commands.CreateProgrammingLanguages;

public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
{
    public string Name { get; set; }
    public class CreateProgrammingLanguagesCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand,CreatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _businessRules;

        public CreateProgrammingLanguagesCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);

            ProgrammingLanguage createdLanguage = await _programmingLanguageRepository.AddAsync(mappedLanguage);

            CreatedProgrammingLanguageDto createdProgrammingLanguageDto =
                _mapper.Map<CreatedProgrammingLanguageDto>(createdLanguage);

            return createdProgrammingLanguageDto;
        }
    }
}