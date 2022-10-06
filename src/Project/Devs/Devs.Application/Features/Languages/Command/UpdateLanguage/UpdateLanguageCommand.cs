using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Command.UpdateLanguage
{
    public class UpdateLanguageCommand :IRequest<UpdateLanguageCommandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageCommandHandler: IRequestHandler<UpdateLanguageCommand,UpdateLanguageCommandDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _businessRules;

            public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules businessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<UpdateLanguageCommandDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language language = _mapper.Map<Language>(request);
                Language updatedLanguage = await _languageRepository.UpdateAsync(language);
                UpdateLanguageCommandDto result = _mapper.Map<UpdateLanguageCommandDto>(updatedLanguage);
                return result;
            }
        }
    }
}
