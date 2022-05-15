using AutoMapper;
using store.Dto.Comment;
using store.Entities;

namespace store.Mapper;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>();
        CreateMap<CommentCreateDto, Comment>();

        CreateMap<Reaction, ReactionDto>();
        CreateMap<ReactionCreateDto, Reaction>();
    }
}