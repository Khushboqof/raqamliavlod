﻿using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Contests;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Contests;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Contests;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Contests
{
    public class ContestService : IContestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaginatorService _paginatorService;

        public ContestService(IUnitOfWork unitOfWork, IPaginatorService paginatorService)
        {
            _unitOfWork = unitOfWork;
            _paginatorService = paginatorService;
        }

        public async Task<bool> CreateAsync(ContestCreateDto contestCreateDto)
        {
            var oldContest = await _unitOfWork.Contests.GetByTitleAsync(contestCreateDto.Title);
            if (oldContest is not null) throw new StatusCodeException(HttpStatusCode.BadRequest, $"There is alredy exist title named by {oldContest.Title}");

            var contest = (Contest)contestCreateDto;
            contest.CreatedAt = TimeHelper.GetCurrentDateTime();
            contest.UpdatedAt = TimeHelper.GetCurrentDateTime();
            //DateTime date1 = contestCreateDto.StartDate;
            //DateTime date2 = contestCreateDto.EndDate;
            //TimeSpan ts = date2 - date1;
            //contest.CalculatedDate = Convert.ToDateTime(ts.ToString());
            await _unitOfWork.Contests.CreateAsync(contest);
            return true;
        }

        public async Task<bool> DeleteAsync(long contestId)
        {
            var oldContest = await _unitOfWork.Contests.FindByIdAsync(contestId);
            if (oldContest is null) throw new StatusCodeException(HttpStatusCode.NotFound, message: "Contest don't exist");

            await _unitOfWork.Contests.DeleteAsync(contestId);

            return true;    
        }

        public async Task<IEnumerable<ContestViewModel>> GetAllAsync(PaginationParams @params)
        {
            var contests = await _unitOfWork.Contests.GetAllAsync(@params);
            _paginatorService.ToPagenator(contests.MetaData);

            var contestViews = new List<ContestViewModel>();

            foreach (var contest in contests)
            {
                var contestView = (ContestViewModel)contest;

                contestViews.Add(contestView);
            }

            return contestViews;
        }

        public async Task<ContestViewModel> GetAsync(long contestId)
        {
            var contest = await _unitOfWork.Contests.FindByIdAsync(contestId);
            if (contest is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Contest is not found");

            return (ContestViewModel)contest;
        }

        public async Task<bool> UpdateAsync(long courseId, ContestCreateDto createDto)
        {
            var contest = await _unitOfWork.Contests.FindByIdAsync(courseId);
            if (contest is null) throw new StatusCodeException(HttpStatusCode.NotFound, message: "Contest is not found");

            var contestTiltle = await _unitOfWork.Contests.GetByTitleAsync(createDto.Title);
            if (contestTiltle is not null && contestTiltle.Title == contest.Title)
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "This title already exist");

            var newContest = (Contest)createDto;
            newContest.Id = courseId;
            newContest.UpdatedAt = TimeHelper.GetCurrentDateTime();

            await _unitOfWork.Contests.UpdateAsync(courseId, newContest);

            return true;
        }
    }
}
