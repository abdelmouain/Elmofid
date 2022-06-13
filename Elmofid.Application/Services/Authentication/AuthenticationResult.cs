using Elmofid.Domain.Entities.Authentication;

namespace Elmofid.Application.Services.Authenticaton;

public record AuthenticationResult(
    User user,
    string Token
);