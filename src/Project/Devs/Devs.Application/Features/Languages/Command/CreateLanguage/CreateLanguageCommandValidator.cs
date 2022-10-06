using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Devs.Application.Features.Languages.Command.CreateLanguage
{
    public class CreateLanguageCommandValidator :AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
        }
    }
}
