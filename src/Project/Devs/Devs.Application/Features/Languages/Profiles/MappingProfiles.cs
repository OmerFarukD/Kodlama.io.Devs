using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Command.CreateLanguage;
using Devs.Application.Features.Languages.Command.DeleteLanguage;
using Devs.Application.Features.Languages.Command.UpdateLanguage;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Models;
using Devs.Domain.Entities;

namespace Devs.Application.Features.Languages.Profiles
{
    internal class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreateLanguageCommandDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language,DeleteLanguageCommandDto>().ReverseMap();
            CreateMap<Language, DeleteBrandCommand>().ReverseMap();
            CreateMap<Language, LanguageListQueryDto>().ReverseMap();
            CreateMap<IPaginate<Language>,LanguageListModel>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommandDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
        }
    }
}
