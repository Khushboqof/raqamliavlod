namespace RaqamliAvlod.Infrastructure.Core.Models
{
    public class CheckerSubmissionResponse : CheckerSubmissionOptions
    {
        public string Result { get; set; } = string.Empty;

        public Dictionary<ushort, ushort> ProcessingTimes { get; set; }
            = new Dictionary<ushort, ushort>();

        public Dictionary<ushort, uint> MemoryUsages { get; set; }
            = new Dictionary<ushort, uint>();

        public bool IsSuccessfull { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }
}