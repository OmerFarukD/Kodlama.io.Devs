using System.Data;
using Devs.Application.Features.Languages.Command;
using Devs.Application.Features.Languages.Command.CreateLanguage;
using Devs.Application.Features.Languages.Command.DeleteLanguage;
using Devs.Application.Features.Languages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        [HttpPost("addlanguage")]
        public async Task<IActionResult> AddLanguage([FromBody]CreateLanguageCommand command)
        {
            CreateLanguageCommandDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpPost("deleteLanguage")]
        public async Task<IActionResult> DeleteLanguage([FromQuery] string name)
        {
            DeleteLanguageCommand command = new DeleteLanguageCommand()
            {
                Name = name
            };
            DeleteLanguageCommandDto result = await Mediator.Send(command);
            
            return Ok(result);
        }
    }
}
