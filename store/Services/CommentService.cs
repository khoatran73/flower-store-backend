using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using store.Dto.Comment;
using store.Entities;

namespace store.Services;

public class CommentService : ICommentService
{
    private readonly IMapper _mapper;
    private readonly henrystoreContext _context;

    public CommentService(IMapper mapper, henrystoreContext context)
    {
        _mapper = mapper;
        _context = context;
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
        var comment = _mapper.Map<CommentCreateDto, Comment>(createDto);
        _context.Add(comment);

        await _context.SaveChangesAsync();
    }
}