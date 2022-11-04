using System;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Common
{
    public interface IServerTimeService
    {
        public DateTime GetCurrentDateTime();
    }
}