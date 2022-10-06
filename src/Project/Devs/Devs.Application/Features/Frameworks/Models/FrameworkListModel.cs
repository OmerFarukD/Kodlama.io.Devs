using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Devs.Application.Features.Frameworks.Dtos;

namespace Devs.Application.Features.Frameworks.Models
{
    public class FrameworkListModel :BasePageableModel
    { 
        public IList<FrameworkListDto> FrameworkListDto { get; set; }
    }
}
