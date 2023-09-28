using BlogProj.Core.Services;
using BlogProj.Shared.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlogProj.Core
{
    public class DIConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoEntityMapperProfile));
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICredentialsService, CredentialsService>();
        }
    }
}