using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Devs.Application.Features.Frameworks.Dtos;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommand :IRequest<CreateFrameworkDto>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreateFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;

            public CreateFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
            }
            public async Task<CreateFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework framework = _mapper.Map<Framework>(request);
                Framework createdFramework = await _frameworkRepository.AddAsync(framework);
                CreateFrameworkDto result = _mapper.Map<CreateFrameworkDto>(createdFramework);
                return result;

            }
        }
    }
}
