using AutoMapper;
using store.Dto.Store;
using store.Entities;

namespace store.Mapper;

public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<Store, StoreDto>();
    }
}