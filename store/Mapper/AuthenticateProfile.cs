using AutoMapper;
using store.Dto.Authenticate;
using store.Entities;

namespace store.Mapper;

public class AuthenticateProfile : Profile
{
    public AuthenticateProfile()
    {
        CreateMap<RegisterDto, Account>();
        CreateMap<LoginDto, Account>();
        CreateMap<Account, AccountDetailDto>();
        CreateMap<Account, AccountDto>();
        CreateMap<AccountCreateDto, Account>();
    }
}