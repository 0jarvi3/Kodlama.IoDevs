﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Futures.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
        if (result.Items.Any()) throw new BusinessException("Brand Name Exist");
    }
}