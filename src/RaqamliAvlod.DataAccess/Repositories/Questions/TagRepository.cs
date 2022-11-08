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

        public async Task<IEnumerable<Tag>> AddRangeAsync(IEnumerable<string> tags)
        {
            List<Tag> entityTags = new();
            foreach (var tag in tags)
            {
                var entityTag = new Tag() { TagName = tag, ViewCount = 0 };
                _dbcontext.Add(entityTag);
                await _dbcontext.SaveChangesAsync();
                entityTags.Add(entityTag);
            }
            return entityTags;
        }

        public async Task<Tag?> FindByNameAsync(string name)
             => await _dbSet.FirstOrDefaultAsync(tag => tag.TagName == name);


    }
}
