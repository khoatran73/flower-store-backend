using store.Dto.Store;

namespace store.Services;

public interface IStoreService
{
    Task<List<StoreDto>> ListStore();
}