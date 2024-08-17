using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Common;

namespace Sanctuary.Data.DbConfigurations
{
    public class DbConfigurator
    {
        public async Task DbConfigurations(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                await using (var command = new SqlCommand(TSQLStatements.FileStreamSetUp, conn)
                {
                    CommandType = CommandType.Text
                })
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
