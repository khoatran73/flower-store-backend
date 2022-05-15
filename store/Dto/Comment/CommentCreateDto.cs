namespace store.Dto.Comment;

public class CommentCreateDto
{
    public Guid? CustomerId { get; set; }
    public Guid? ProductId { get; set; }
    public string? Content { get; set; }
}