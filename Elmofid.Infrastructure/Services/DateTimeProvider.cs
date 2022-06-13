using Elmofid.Application.Common.Interfaces.Services;

namespace Elmofid.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
