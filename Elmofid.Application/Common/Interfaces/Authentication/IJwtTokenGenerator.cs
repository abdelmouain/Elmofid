using Elmofid.Domain.Entities.Authentication;

namespace Elmofid.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string Generate(User user);
    }
}
