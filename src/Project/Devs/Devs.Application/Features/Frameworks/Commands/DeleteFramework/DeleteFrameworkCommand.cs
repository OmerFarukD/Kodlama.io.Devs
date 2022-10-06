using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Devs.Application.Features.Frameworks.Dtos;
using Devs.Application.Features.Frameworks.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommand :IRequest<DeleteFrameworkDto>
    {
        public int Id { get; set; }

        public class DeleteFrameworkCommandHandler: IRequestHandler<DeleteFrameworkCommand,DeleteFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;
            public DeleteFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper,FrameworkBusinessRules frameworkBusinessRules)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _frameworkBusinessRules = frameworkBusinessRules;
            }
            public async Task<DeleteFrameworkDto> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
            {
                await _frameworkBusinessRules.FrameworkFoundById(request.Id);


                Framework? framework = await _frameworkRepository.GetAsync(f=>f.Id==request.Id);
                Framework deletedFramework = await _frameworkRepository.DeleteAsync(framework);
                DeleteFrameworkDto result = _mapper.Map<DeleteFrameworkDto>(deletedFramework);
                return result;
            }
        }
    }
}
