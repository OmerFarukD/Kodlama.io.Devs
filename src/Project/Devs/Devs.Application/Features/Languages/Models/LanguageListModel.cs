using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Devs.Application.Features.Languages.Dtos;

namespace Devs.Application.Features.Languages.Models
{
    public class LanguageListModel : BasePageableModel
    {
        public LanguageListQueryDto GetListQueryDto { get; set; }
    }
}
