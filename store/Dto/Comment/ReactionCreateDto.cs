namespace store.Dto.Comment;

public class ReactionCreateDto
{
    public Guid CustomerId { get; set; }
    public Guid CommentId { get; set; }
}