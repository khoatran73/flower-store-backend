using store.Dto.Comment;

namespace store.Services;

public interface ICommentService
{
    Task<List<CommentDto>> GetListAsync(Guid? productId);
    Task CreateAsync(CommentCreateDto createDto);
    // Task CreateReaction(ReactionDto createDto);
}