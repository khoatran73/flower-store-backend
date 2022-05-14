using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using store.Dto.Store;
using store.Entities;

namespace store.Services;

public class StoreService : IStoreService
{
    private IMapper _mapper;
    private henrystoreContext _context;

    public StoreService(IMapper mapper, henrystoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<StoreDto>> ListStore(Guid? storeId)
    {
        var db = SwapConnectionString.SwapDB(storeId);
        var storeDtos = await db.Stores
            .Select(x => x)
            .ProjectTo<StoreDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        return storeDtos;
    }
}