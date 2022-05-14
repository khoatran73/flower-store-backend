using AutoMapper;
using store.Dto.Authenticate;
using store.Dto.User;
using store.Entities;

namespace store.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<staff, UserDto>();
        CreateMap<UserCreateDto, staff>();
        CreateMap<Customer, UserDto>();
        CreateMap<UserCreateDto, Customer>();

        CreateMap<RegisterDto, Customer>();
        CreateMap<Customer, AccountDto>();
        CreateMap<staff, AccountDto>();
        CreateMap<Customer, AccountDetailDto>();
        CreateMap<staff, AccountDetailDto>();

        CreateMap<AccountCreateDto, staff>();
        CreateMap<CustomerUpdateDto, Customer>();
    }
}