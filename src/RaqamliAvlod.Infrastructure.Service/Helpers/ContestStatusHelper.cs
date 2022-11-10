using RaqamliAvlod.Domain.Enums;

namespace RaqamliAvlod.Infrastructure.Service.Helpers
{
    public class ContestStatusHelper
    {
        public static ContestStatus GetStatus(DateTime startDate, DateTime endDate)
        {
            DateTime now = TimeHelper.GetCurrentDateTime();
            if (now < startDate) return ContestStatus.Pending;
            else if (now >= startDate && now <= endDate) return ContestStatus.Started;
            else return ContestStatus.Finished;
        }
    }
}