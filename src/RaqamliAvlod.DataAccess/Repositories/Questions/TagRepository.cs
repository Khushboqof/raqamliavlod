using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Questions;
using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.DataAccess.Repositories.Questions
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> FindByTagNameAsync(string tagName)
        {
            var tag = await _dbSet.FirstOrDefaultAsync(tag => tag.TagName == tagName);
            return tag is not null ? true : false;
        }
    }
}
