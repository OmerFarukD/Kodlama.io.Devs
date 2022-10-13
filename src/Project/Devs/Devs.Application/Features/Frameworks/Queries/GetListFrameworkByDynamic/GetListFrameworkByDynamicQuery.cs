using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Devs.Application.Features.Frameworks.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Features.Frameworks.Queries.GetListFrameworkByDynamic
{
    public class GetListFrameworkByDynamicQuery :IRequest<FrameworkListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetListFrameworkByDynamicQueryHandler:IRequestHandler<GetListFrameworkByDynamicQuery,FrameworkListModel>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public GetListFrameworkByDynamicQueryHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }
            public async Task<FrameworkListModel> Handle(GetListFrameworkByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameworkPaginate = await _frameworkRepository.GetListByDynamicAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize, dynamic: request.Dynamic,
                    include:m=>m.Include(a=>a.Language));

                FrameworkListModel model = _mapper.Map<FrameworkListModel>(frameworkPaginate);
                return model;
            }
        }
    }
    
}
