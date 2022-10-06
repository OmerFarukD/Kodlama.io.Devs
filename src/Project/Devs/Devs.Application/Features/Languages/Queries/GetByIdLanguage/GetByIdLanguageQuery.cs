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

namespace Devs.Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery :IRequest<GetByIdLanguageDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageQueryHandler:IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _businessRules;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules businessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(b =>b.Id==request.Id);
                GetByIdLanguageDto getByIdLanguageDto = _mapper.Map<GetByIdLanguageDto>(language);
                return getByIdLanguageDto;
            }
        }
    }
}
