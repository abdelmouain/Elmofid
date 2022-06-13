using Elmofid.Application.Common.Interfaces.Persistence;
using Elmofid.Domain.Entities.Authentication;

namespace Elmofid.Infrastructure.Persistence.Authentication
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
