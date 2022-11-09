using Microsoft.IdentityModel.Tokens;
using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Questions
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(string tagName)
        {
            var tags = await _unitOfWork.Tags.FindByNameAsync(tagName.ToLower());

            var tag = new TagCreateDto();
            tag.TagName = tagName;

            if (tags is not null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Tag already exists");

            return await _unitOfWork.Tags.CreateAsync(tag) is not null;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var tag = await _unitOfWork.Tags.FindByIdAsync(id);
            if (tag is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Tag not found");

            await _unitOfWork.Tags.DeleteAsync(id);

            return true;
        }

        public async Task<bool> UpdateAsync(long id, TagCreateDto dto)
        {
            var tag = await _unitOfWork.Tags.FindByIdAsync(id);

            if (tag is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Tag not found");

            await _unitOfWork.Tags.UpdateAsync(id, dto);

            return true;
        }

        public async Task<TagViewModel> GetByIdAsync(long tagId)
        {
            var tag = await _unitOfWork.Tags.FindByIdAsync(tagId);

            if (tag is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Tag not found");

            return (TagViewModel)tag;
        }

        public async Task<IEnumerable<Tag?>> GetByNameAsync(string name)
        {
            var tag = await _unitOfWork.Tags.SearchAsync(name.ToLower());

            if (tag.IsNullOrEmpty())
                throw new StatusCodeException(HttpStatusCode.NotFound, "Tag not found");

            return tag;
        }
    }
}
