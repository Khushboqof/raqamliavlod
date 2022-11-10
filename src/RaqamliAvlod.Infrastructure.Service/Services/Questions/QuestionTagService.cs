using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Questions;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;

namespace RaqamliAvlod.Infrastructure.Service.Services.Questions
{
    public class QuestionTagService : IQuestionTagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionTagService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(Question question, IEnumerable<string> newTags)
        {
            List<QuestionTag> questionTags = new();
            List<string> tags = new();
            foreach (var tagdto in newTags)
            {
                var tag = await _unitOfWork.Tags.FindByNameAsync(tagdto);
                if (tag is null)
                    tags.Add(tagdto.ToLower());
                else questionTags.Add(new QuestionTag() { QuestionId = question.Id, TagId = tag.Id });
            }
            var createdTags = await _unitOfWork.Tags.AddRangeAsync(tags.Distinct());


            foreach (var tag in createdTags)
                questionTags.Add(new QuestionTag() { QuestionId = question.Id, TagId = tag.Id });
            await _unitOfWork.QuestionTags.AddRangeAsync(questionTags.DistinctBy(x => x.TagId));
            return true;
        }

        public async Task<bool> UpdateAsync(Question question, IEnumerable<string> tags)
        {
            await _unitOfWork.QuestionTags.DeleteQuestionTagsAsync(question.Id);
            await CreateAsync(question, tags);
            return true;
        }
    }
}
