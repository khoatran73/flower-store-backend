using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.Authenticate;
using store.Entities;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/auth")]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticateService _authenticateService;
    private readonly IFileService _fileService;

    public AuthenticateController(IAuthenticateService authenticateService, IFileService fileService)
    {
        _authenticateService = authenticateService;
        _fileService = fileService;
    }
    
    // [HttpGet(@"list-account")]
    // public async Task<IActionResult> GetListAccount()
    // {
    //     var result = await _authenticateService.GetListAccount();
    //     return Ok(new ApiResponse<List<AccountDto>>()
    //     {
    //         Success = true,
    //         Message = "",
    //         Result = result
    //     });
    // }
    
    [HttpGet(@"{id:guid}")]
    public async Task<IActionResult> GetAccount([FromRoute] Guid id)
    {
        var result = await _authenticateService.GetAccount(id);
        return Ok(new ApiResponse<AccountDto>()
        {
            Success = true,
            Message = "",
            Result = result
        });
    }
    
    [HttpPost(@"register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _authenticateService.Register(registerDto);

        return Ok(new ApiResponse<bool>()
        {
            Success = true,
            Message = "",
            Result = result,
        });
    }
    
    [HttpPost(@"login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _authenticateService.Login(loginDto);

        return Ok(new ApiResponse<AccountDetailDto>()
        {
            Success = true,
            Message = "",
            Result = result,
        });
    }
    
    [HttpPost(@"reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
    {
        await _authenticateService.ResetPassword(resetPasswordDto);

        return Ok(new ApiResponse<bool>()
        {
            Success = true,
            Message = "",
        });
    }
}