using AutoMapper;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Command.CreateLanguage
{
    public class CreateLanguageCommand :IRequest<CreateLanguageCommandDto>
    {
        public string Name { get; set; }
        public class CreateLanguageCommandHandler: IRequestHandler<CreateLanguageCommand,CreateLanguageCommandDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _businessRules;

            public CreateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules businessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<CreateLanguageCommandDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                Language language = _mapper.Map<Language>(request);
                Language createdLanguage = await _languageRepository.AddAsync(language);
                CreateLanguageCommandDto result = _mapper.Map<CreateLanguageCommandDto>(createdLanguage);
                return result;
            }
        }
    }
}
