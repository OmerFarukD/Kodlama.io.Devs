using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> language = await _languageRepository.GetListAsync(l=>l.Name==name);
            if (language.Items.Any()) throw new BusinessException("Language name exists");
        }
    }
}
