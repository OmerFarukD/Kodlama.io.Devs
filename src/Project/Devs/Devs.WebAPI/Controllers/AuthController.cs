using Core.Security.Dtos;
using Core.Security.Entities;
using Devs.Application.Features.Auths.Commands.Dtos;
using Devs.Application.Features.Auths.Commands.Login;
using Devs.Application.Features.Auths.Commands.Register;
using Devs.Application.Features.Auths.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand command = new()
            {
                IpAddress = GetIpAddress(),
                UserForLoginDto = userForLoginDto
            };

            LoginedDto result = await Mediator.Send(command);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("",result.AccessToken);
        }
        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

    }
}
