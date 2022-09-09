using Application.Futures.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Futures.ProgrammingLanguages.Queries;

public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery,ProgrammingLanguageListModel>
    {
        private readonly IMapper _mapper;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public GetListProgrammingLanguageQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> languages = 
                await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            ProgrammingLanguageListModel model = _mapper.Map<ProgrammingLanguageListModel>(languages);
            return model;
        }
    }
}