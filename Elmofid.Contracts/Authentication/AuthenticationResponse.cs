namespace Elmofid.Contracts.Authenticaton;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);