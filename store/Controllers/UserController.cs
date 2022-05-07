﻿using Microsoft.AspNetCore.Mvc;
using store.Api;
using store.Dto.User;
using store.Services;

namespace store.Controllers;

[ApiController]
[Route(@"api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IFileService _fileService;


    public UserController(IUserService userService, IFileService fileService)
    {
        _userService = userService;
        _fileService = fileService;
    }

    [HttpPost(@"create-staff")]
    public async Task<IActionResult> Register([FromBody] UserCreateDto createDto)
    {
        var filePath = await _fileService.UploadFile(createDto.Account.File, "Uploads/staff");
        createDto.Account.Image = filePath;

        await _userService.CreateStaff(createDto);

        return Ok(new ApiResponse<bool>()
        {
            Success = true,
            Message = "",
        });
    }

    [HttpGet(@"list-staff")]
    public async Task<IActionResult> ListStaff()
    {
        var result = await _userService.ListStaff();

        return Ok(new ApiResponse<List<UserDto>>()
        {
            Success = true,
            Message = "",
            Result = result,
        });
    }
}