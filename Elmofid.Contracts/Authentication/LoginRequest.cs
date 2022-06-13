namespace Elmofid.Contracts.Authenticaton;

public record LoginRequest(
    string Email,
    string Password);