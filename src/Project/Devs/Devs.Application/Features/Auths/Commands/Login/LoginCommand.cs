using Core.Security.Dtos;
using Core.Security.Entities;
using Devs.Application.Features.Auths.Dtos;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Services.AuthServices;
using Devs.Application.Services.Repositories;
using Devs.Application.Services.UserServices;
using MediatR;

namespace Devs.Application.Features.Auths.Commands.Login
{
    public class LoginCommand :IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler:IRequestHandler<LoginCommand,LoginedDto>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
            public LoginCommandHandler(IUserService userService, IAuthService authService,AuthBusinessRules businessRules)
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = businessRules;
            }
            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userService.GetByEmail(request.UserForLoginDto.Email);


                await _authBusinessRules.UserEmailShouldBeExists(request.UserForLoginDto.Email);
                await _authBusinessRules.UserPasswordShouldBeMatch(user.Id,request.UserForLoginDto.Password);

                var accessToken = await _authService.CreateAccessToken(user);
                var createdRefreshToken = await _authService.CreateRefreshToken(user,request.IpAddress);
                var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
                LoginedDto loginedDto = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = addedRefreshToken
                };
                return loginedDto;
            }
        }
    }
}
