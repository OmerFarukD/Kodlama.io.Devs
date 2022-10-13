using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Frameworks.Commands.CreateFramework;
using Devs.Application.Features.Frameworks.Commands.DeleteFramework;
using Devs.Application.Features.Frameworks.Dtos;
using Devs.Application.Features.Frameworks.Models;
using Devs.Application.Features.Languages.Dtos;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Frameworks.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Framework, CreateFrameworkCommand>().ForMember(c=>c.LanguageId,opt=>opt.MapFrom(c=>c.Language.Id)).ReverseMap();
            CreateMap<Framework, CreateFrameworkDto>().ForMember(c => c.LanguageId, opt => opt.MapFrom(c => c.Language.Id)).ReverseMap();
            CreateMap<Framework, DeleteFrameworkDto>().ReverseMap();
            CreateMap<Framework, DeleteFrameworkCommand>().ReverseMap();
            CreateMap<Framework, FrameworkListDto>().ForMember(c=>c.LanguageId,opt=>opt.MapFrom(c=>c.Language)).ReverseMap();
            CreateMap<IPaginate<Framework>, FrameworkListModel>().ReverseMap();
        }
    }
}
