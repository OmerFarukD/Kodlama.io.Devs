using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Models;
using Devs.Application.Features.Languages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageQueryHandler :IRequestHandler<GetListLanguageQuery,LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _businessRules;

            public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules businessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> languages = await _languageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                LanguageListModel model = _mapper.Map<LanguageListModel>(languages);
                return model;
            }
        }
    }
}
