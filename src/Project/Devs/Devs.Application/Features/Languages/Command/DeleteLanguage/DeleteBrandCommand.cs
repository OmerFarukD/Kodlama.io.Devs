﻿using System;
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

namespace Devs.Application.Features.Languages.Command.DeleteLanguage
{
    public class DeleteBrandCommand :IRequest<DeleteLanguageCommandDto>
    {
        public string Name { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteLanguageCommandDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeleteBrandCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }
            public async Task<DeleteLanguageCommandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Language language = _mapper.Map<Language>(request);
                Language deletedLanguage = await _languageRepository.DeleteAsync(language);
                DeleteLanguageCommandDto result = _mapper.Map<DeleteLanguageCommandDto>(deletedLanguage);
                return result;
            }
        }
    }
}
