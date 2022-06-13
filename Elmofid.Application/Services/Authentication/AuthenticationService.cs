using Elmofid.Application.Common.Interfaces.Authentication;

namespace Elmofid.Application.Services.Authenticaton;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "Mouain", "Chine", email, "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exist

        var userId = Guid.NewGuid();
        //Create user (unique ID)

        //Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }
}