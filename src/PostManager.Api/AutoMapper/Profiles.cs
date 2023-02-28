using AutoMapper;
using PostManager.Api.Dtos.Audit;
using PostManager.Api.Dtos.Post;
using PostManager.Api.Dtos.User;
using PostManager.Api.Entities;

namespace PostManager.Api.Mapper
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<User, AuthorDto>();
            CreateMap<User, UserDto>();
            CreateMap<Post, PostDto>()
              .ForMember(x => x.Author, m => m.MapFrom(qf => qf.User));
            CreateMap<Audit, AuditDto>()
              .ForMember(x => x.CreatedDate, m => m.MapFrom(qf => qf.CreatedAt));

        }
        
    }
}
