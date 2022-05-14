using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace store;

public static class ConnectionTools
{
    public static void ChangeDatabase(
        this DbContext source,
        string connectionString)
    {
        try
        {
            source.Database.SetConnectionString(connectionString);
        }
        catch (Exception ex)
        {
            // set log item if required
        }
    }
}