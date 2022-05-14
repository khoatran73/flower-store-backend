// using Microsoft.AspNetCore.Mvc;
//
// namespace store.Controllers;
//
//
// [ApiController]
// [Route(@"api/connect")]
// public class ConnectController: ControllerBase
//
// {
//     private const string StoreId1 = "AEABAAAD-9B84-4E09-BCC2-1FF599F3B760";
//     private const string StoreId2 = "6046DAF4-1229-432B-B3CB-85F87C1DCBDB";
//
//     [HttpGet(@"{storeId:guid}")]
//     public Task Connect(Guid storeId)
//     {
//         switch (storeId.ToString())
//         {
//             case StoreId1:
//                 ConnectionTools.ConnectionString = "Data Source=KHOA-PRO\\TRAM1;Initial Catalog=henrystore;User ID=sa;Password=123456";
//                 return Task.CompletedTask;
//             case StoreId2:
//                 ConnectionTools.ConnectionString = "Data Source=KHOA-PRO\\TRAM2;Initial Catalog=henrystore;User ID=sa;Password=123456";
//                 return Task.CompletedTask;
//             default:
//                 ConnectionTools.ConnectionString = "Data Source=KHOA-PRO\\MAYCHU;Initial Catalog=henrystore;User ID=sa;Password=123456";
//                 return Task.CompletedTask;
//         }
//     }
// }