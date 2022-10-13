using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Devs.Application.Features.Frameworks.Commands.CreateFramework;
using Devs.Application.Features.Frameworks.Commands.DeleteFramework;
using Devs.Application.Features.Frameworks.Dtos;
using Devs.Application.Features.Frameworks.Models;
using Devs.Application.Features.Frameworks.Queries.GetListByFramework;
using Devs.Application.Features.Frameworks.Queries.GetListFrameworkByDynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] CreateFrameworkCommand createFrameworkCommand)
        {
            CreateFrameworkDto result = await Mediator.Send(createFrameworkCommand);
            return Created("", result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteFrameworkCommand deleteFrameworkCommand)
        {
            DeleteFrameworkDto result = await Mediator.Send(deleteFrameworkCommand);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListByFrameworkQuery query = new() { PageRequest = pageRequest };

            FrameworkListModel model = await Mediator.Send(query);

            return Ok(model);
        }

        [HttpPost("getlistbydynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListFrameworkByDynamicQuery query = new()
            {
                Dynamic = dynamic,
                PageRequest = pageRequest
            };
            FrameworkListModel model = await Mediator.Send(query);

            return Ok(model);
        }
    }
}
