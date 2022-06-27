using Elmofid.Domain.Entities.Authentication;

namespace Elmofid.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);