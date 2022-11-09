using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.DataAccess.Interfaces.Questions
{
    public interface ITagRepository : IRepository<Tag>
    {
        public Task<Tag?> FindByNameAsync(string name);

        public Task<IEnumerable<Tag?>> SearchAsync(string name);

        public Task<IEnumerable<Tag>> AddRangeAsync(IEnumerable<string> tags);
    }
}