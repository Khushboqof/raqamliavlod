using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace RaqamliAvlod.Infrastructure.Service.Services.Courses;

public class CourseVideoService : ICourseVideoService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseVideoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> CreateAsync(CourseVideoCreateDto dto)
    { 
        var course = await _unitOfWork.Courses.FindByIdAsync(dto.CourseId);

        if(course is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

        var video = await new YoutubeClient().Videos.GetAsync(YouTubeVideoIdExtractor(dto.Link));

        var courseVideoCreate = (CourseVideo)dto;

        courseVideoCreate.CourseId = dto.CourseId;
        courseVideoCreate.YouTubeLink = video.Url;
        courseVideoCreate.Title = video.Title;
        courseVideoCreate.Description = video.Description;
        courseVideoCreate.Duration = video.Duration!.Value.Minutes;
        courseVideoCreate.YouTubeThumbnail = video.Thumbnails.OrderByDescending(p => p.Resolution.Height).FirstOrDefault()!.Url;

        var res = await _unitOfWork.CourseVideos.CreateAsync(courseVideoCreate);

        return res is not null ? true : false;
    }

    public Task<bool> DeleteAsync(long courseVideoId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CourseVideoViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long courseVideoId, CourseVideoUpdateDto dto)
    {
        throw new NotImplementedException();
    }


    private string YouTubeVideoIdExtractor(string link)
    {
        if (!IsYouTubeLink(link))
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Invalid Youtube link!");

        return link;
    }
    private bool IsYouTubeLink(string link)
    {
        try
        {
            Uri uri = new Uri(link);

            return uri.Host == "www.youtube.com" || uri.Host == "youtube.com" ||
                        uri.Host == "www.youtu.be" || uri.Host == "youtu.be";
        }
        catch (Exception)
        {
            return false;
        }
    }
}
