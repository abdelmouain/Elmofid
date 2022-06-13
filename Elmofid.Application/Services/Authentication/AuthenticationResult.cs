namespace Elmofid.Application.Services.Authenticaton;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string email,
    string Token
);