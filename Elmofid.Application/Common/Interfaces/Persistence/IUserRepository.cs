using Elmofid.Domain.Entities.Authentication;

namespace Elmofid.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetByEmail(string email);
    }
}
