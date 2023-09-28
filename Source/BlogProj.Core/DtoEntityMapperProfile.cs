using AutoMapper;
using BlogProj.Shared.Dtos.BlogDtos;
using BlogProj.Shared.Dtos.CommentDtos;
using BlogProj.Shared.Dtos.Credentials;
using BlogProj.Shared.Dtos.CredentialsDtos;
using BlogProj.Shared.Dtos.PostDtos;
using BlogProj.Shared.Dtos.UserDtos;
using BlogProj.Shared.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace BlogProj.Core
{
    public class DtoEntityMapperProfile : Profile
    {
        public DtoEntityMapperProfile()
        {
            CreateMap<BlogCreate, Blog>()
                .ForMember(destination => destination.Id, options => options.Ignore());
            CreateMap<BlogUpdate, Blog>();
            CreateMap<Blog, BlogGet>();

            CreateMap<UserCreate, User>()
                .ForMember(destination => destination.Id, options => options.Ignore());
            CreateMap<UserUpdate, User>();
            CreateMap<User, UserGet>();

            CreateMap<PostCreate, Post>()
                .ForMember(destination => destination.Id, options => options.Ignore());
            CreateMap<PostUpdate, Post>();
            CreateMap<Post, PostGet>();

            CreateMap<CommentCreate, Comment>()
                .ForMember(destination => destination.Id, options => options.Ignore());
            CreateMap<CommentUpdate, Comment>();
            CreateMap<Comment, CommentGet>();

            CreateMap<CredentialsCreate, Credentials>()
                .ForMember(destination => destination.Id, options => options.Ignore());
            CreateMap<CredentialsUpdate, Credentials>();
            CreateMap<Credentials, CredentialsGet>();
        }
    }
}