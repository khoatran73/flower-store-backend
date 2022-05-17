using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using store.Dto.Comment;
using store.Entities;

namespace store.Services;

public class CommentService : ICommentService
{
    private readonly IMapper _mapper;
    private readonly henrystoreContext _context;
    private readonly IValidator<CommentCreateDto> _validator;

    public CommentService(IMapper mapper, henrystoreContext context, IValidator<CommentCreateDto> validator)
    {
        _mapper = mapper;
        _context = context;
        _validator = validator;
    }

    public async Task<List<CommentDto>> GetListAsync(Guid? productId)
    {
        var commentDtos = await _context.Comments
            .Where(x => x.ProductId == productId)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return commentDtos;
    }

    public async Task CreateAsync(CommentCreateDto createDto)
    {
        var validate = await _validator.ValidateAsync(createDto);

        if (!validate.IsValid)
            throw new Exception("cannot null");


        var comment = _mapper.Map<CommentCreateDto, Comment>(createDto);
        _context.Add(comment);

        await _context.SaveChangesAsync();
    }

    public async Task CreateReaction(ReactionCreateDto createDto)
    {
        var existReaction = _context.Reactions
            .FirstOrDefault(x => x.CommentId == createDto.CommentId && x.CustomerId == createDto.CustomerId);

        if (existReaction != null)
        {
            _context.Remove(existReaction);

            await _context.SaveChangesAsync();
        }
        else
        {
            var reaction = _mapper.Map<ReactionCreateDto, Reaction>(createDto);

            _context.Add(reaction);

            await _context.SaveChangesAsync();
        }
    }
}