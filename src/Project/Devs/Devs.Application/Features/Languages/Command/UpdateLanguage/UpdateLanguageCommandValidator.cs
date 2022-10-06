using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Devs.Application.Features.Languages.Command.UpdateLanguage
{
    public class UpdateLanguageCommandValidator :AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
        }
    }
}
