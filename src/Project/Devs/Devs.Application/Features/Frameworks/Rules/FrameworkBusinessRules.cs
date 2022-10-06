using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Features.Frameworks.Rules
{
    public class FrameworkBusinessRules
    {
        private readonly IFrameworkRepository _frameworkRepository;

        public FrameworkBusinessRules(IFrameworkRepository frameworkRepository)
        {
            _frameworkRepository = frameworkRepository;
        }

        public async Task FrameworkFoundById(int id)
        {
            var result = await _frameworkRepository.GetAsync(b => b.Id == id);
            if (result is null) throw new BusinessException("Belirtilen Id de Framework bulunamadı.");
        }
    }
}
