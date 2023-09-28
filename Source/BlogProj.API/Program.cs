using AutoMapper;
using BlogProj.API.Controllers;
using BlogProj.Core;
using BlogProj.Core.Services;
using BlogProj.Data;
using BlogProj.Data.Repositories;
using BlogProj.Shared.Interfaces.Repositories;

namespace BlogProj.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // my code *****
            DIConfiguration.RegisterServices(builder.Services);
            builder.Services.AddDbContext<DataBaseContext>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICredentialsRepository, CredentialsRepository>();

            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                //dataBaseContext.Database.EnsureDeleted();
                dataBaseContext.Database.EnsureCreated();
            }
            // *****

                builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}