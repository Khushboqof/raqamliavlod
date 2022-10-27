namespace RaqamliAvlod.Application.ViewModels.Questions.Queries
{
    public class QuestionViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int ViewCount { get; set; }
        public string[]? Tags { get; set; }
    }
}
