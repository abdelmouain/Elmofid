using Elmofid.Application.Common.Interfaces.Authentication;
using Elmofid.Application.Common.Interfaces.Persistence;
using Elmofid.Domain.Entities.Authentication;

namespace Elmofid.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        //1.Validate the user exists
        if (_userRepository.GetByEmail(email) is not User user) throw new Exception("User with given email does not exist.");

        //2.Validate the password is correct
        if (user.Password != password) throw new Exception("Invalid password.");

        //3.Generate Jwt token
        var token = _jwtTokenGenerator.Generate(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1.Validate the user exists
        if (_userRepository.GetByEmail(email) is not null)
        {
            throw new Exception("User with given email already exist");
        }

        //2.Create user (unique ID)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

        //3.Generate JWT token
        var token = _jwtTokenGenerator.Generate(user);

        return new AuthenticationResult(user, token);
    }
}