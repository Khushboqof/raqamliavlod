namespace RaqamliAvlod.Application.ViewModels.Questions.Commands
{
    public class QuestionCreateViewModel
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string[]? Tags { get; set; }
    }
}
