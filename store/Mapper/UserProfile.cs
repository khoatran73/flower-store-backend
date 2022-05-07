﻿using AutoMapper;
using store.Dto.User;
using store.Entities;

namespace store.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<staff, UserDto>();
        CreateMap<UserCreateDto, staff>();
    }
}