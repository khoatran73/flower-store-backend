using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.Comment;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/comment")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet(@"{productId:guid}")]
    public async Task<IActionResult> ListProductsSold([FromRoute] Guid productId)
    {
        var result = await _commentService.GetListAsync(productId);
        return Ok(new ApiResponse<List<CommentDto>>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
    
    [HttpPost(@"create")]
    public async Task<IActionResult> CreateAsync([FromBody] CommentCreateDto createDto)
    {
        await _commentService.CreateAsync(createDto);
        return Ok(new ApiResponse<bool>()
        {
            Success = true,
            Message = "",
            // Result = result
        });
    }
    
    [HttpPost(@"reaction/create")]
    public async Task<IActionResult> CreateReaction([FromBody] ReactionCreateDto createDto)
    {
        await _commentService.CreateReaction(createDto);
        return Ok(new ApiResponse<bool>()
        {
            Success = true,
            Message = "",
        });
    }
}