﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;

namespace RaqamliAvlod.Infrastructure.Service.Services.Common;

public class PaginatorServcie : IPaginatorService
{
    private readonly IHttpContextAccessor _accessor;

    public PaginatorServcie(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    public void ToPagenator(PaginationMetaData metaData)
    {
        _accessor.HttpContext.Response.Headers.Add("X-Pagination",
            JsonConvert.SerializeObject(metaData));
    }
}
