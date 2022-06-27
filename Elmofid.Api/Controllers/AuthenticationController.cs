using Elmofid.Application.Services.Authentication;
using Elmofid.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Elmofid.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        Console.WriteLine($"--> Register {request.FirstName}");
        var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var authResponse =  new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        Console.WriteLine($"--> Register done!");
        return Ok(authResponse);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        Console.WriteLine($"--> Login {request.Email}");
        var authResult = _authenticationService.Login(request.Email, request.Password);
        var authResponse =  new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        Console.WriteLine($"--> Login done!");
        return Ok(authResponse);
    }
}