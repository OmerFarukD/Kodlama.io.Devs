using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.Frameworks.Models;
using Devs.Application.Features.Frameworks.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Frameworks.Queries.GetListByFramework
{
    public class GetListByFrameworkQuery :IRequest<FrameworkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListByFrameworkQueryHandler : IRequestHandler<GetListByFrameworkQuery, FrameworkListModel>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public GetListByFrameworkQueryHandler(IFrameworkRepository frameworkRepository, IMapper mapper, FrameworkBusinessRules frameworkBusinessRules)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _frameworkBusinessRules = frameworkBusinessRules;
            }
            public async Task<FrameworkListModel> Handle(GetListByFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameworks = await _frameworkRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize
                ,include: m=>m.Include(f=>f.Language)
                );

                FrameworkListModel results = _mapper.Map<FrameworkListModel>(frameworks);
                return results;
            }
        }
    }
}
