using AutoMapper;
using store.Dto.Comment;
using store.Entities;

namespace store.Mapper;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>()
            .ForMember(x => x.CountLike, opt =>
                opt.MapFrom(x => x.Reactions.Count));
        CreateMap<CommentCreateDto, Comment>();

        CreateMap<Reaction, ReactionDto>();
        CreateMap<ReactionCreateDto, Reaction>();
    }
}