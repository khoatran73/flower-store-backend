using store.Dto.User;
using store.Entities;

namespace store.Dto.Comment;

public class CommentDto
{
    public Guid Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? ProductId { get; set; }
    public string? Content { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int CountLike { get; set; }
    public virtual UserDto? Customer { get; set; }
    public virtual ICollection<ReactionDto> Reactions { get; set; }
}