using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;
using RaqamliAvlod.Infrastructure.Service.Security;
using RaqamliAvlod.Infrastructure.Service.Services.Common;
using RaqamliAvlod.Infrastructure.Service.Services.Courses;

namespace RaqamliAvlod.Api.Configurations.Dependencies
{
    public static class ServiceLayerConfiguration
    {
        public static void AddServiceLayer(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPaginatorService, PaginatorServcie>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
