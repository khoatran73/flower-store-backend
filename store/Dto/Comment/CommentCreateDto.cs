using FluentValidation;

namespace store.Dto.Comment;

public class CommentCreateDto
{
    public Guid? CustomerId { get; set; }
    public Guid? ProductId { get; set; }
    public string? Content { get; set; }
}

public class ValidateCommentCreateDto : AbstractValidator<CommentCreateDto>
{
    public ValidateCommentCreateDto()
    {
        RuleFor(x => x.CustomerId).NotNull().NotEmpty();
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
        RuleFor(x => x.Content).NotNull().NotEmpty();
    }
}