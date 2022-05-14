using store.Entities;

namespace store;

public static class SwapConnectionString
{
    private const string StoreId1 = "AEABAAAD-9B84-4E09-BCC2-1FF599F3B760";
    private const string StoreId2 = "6046DAF4-1229-432B-B3CB-85F87C1DCBDB";
     
    public static henrystoreContext SwapDB(Guid? storeId)
    {
        var selectedDB = new henrystoreContext();
        var connectionString = storeId.ToString().ToUpper() switch
        {
            StoreId1 => "Data Source=KHOA-PRO\\TRAM1;Initial Catalog=henrystore;User ID=sa;Password=123456",
            StoreId2 => "Data Source=KHOA-PRO\\TRAM2;Initial Catalog=henrystore;User ID=sa;Password=123456",
            _ => "Data Source=KHOA-PRO\\MAYCHU;Initial Catalog=henrystore;User ID=sa;Password=123456"
        };
        selectedDB.ChangeDatabase(connectionString);
        
        return selectedDB;
    }
}