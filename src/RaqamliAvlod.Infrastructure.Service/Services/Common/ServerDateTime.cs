using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;

namespace RaqamliAvlod.Infrastructure.Service.Services.Common
{
    public class ServerDateTime : IServerTimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}