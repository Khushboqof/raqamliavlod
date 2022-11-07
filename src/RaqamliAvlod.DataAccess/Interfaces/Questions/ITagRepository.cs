using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.DataAccess.Interfaces.Questions
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag?> FindByNameAsync(string name);
    }
}