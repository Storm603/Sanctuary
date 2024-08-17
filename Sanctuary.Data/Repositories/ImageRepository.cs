using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using Sanctuary.Data.Models.PicturesTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Sanctuary.Data.Repositories
{
    public class ImageRepository<TPicture> : BaseRepository<TPicture>, IImageRepository<TPicture>
        where TPicture : ImageStorage
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task AddAsync(TPicture entity) => this.DbSet.AddAsync(entity).AsTask();

        public override IQueryable<TPicture> All() => DbSet;

        public override IQueryable<TPicture> AllAsNoTracking()
        {
            throw new NotImplementedException();
        }

        public async Task<Stream?> GetImageByPk(string picturePk, SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(base.Context.Database.GetConnectionString());
            await conn.OpenAsync();
            SqlTransaction tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            command.Connection = conn;
            command.Transaction = tran;

            Stream? fileStream = null;

            //var parameter = new SqlParameter("@PicturePkId", Guid.Parse(picturePk));
            command.Parameters.Add("@PicturePkId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(picturePk);

            try
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if (await reader.IsDBNullAsync(0))
                        {
                            return null;
                        }

                        // Get the pointer for the file
                        string path = reader.GetString(0);
                        byte[] transactionContext = reader.GetSqlBytes(1).Buffer!;

                        // Create the SqlFileStream
                        fileStream = new SqlFileStream(path, transactionContext, FileAccess.Read, FileOptions.SequentialScan, allocationSize: 0);

                        if (fileStream.CanRead)
                        {
                            //await conn.CloseAsync();
                            //await tran.DisposeAsync();
                            return fileStream;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            await conn.CloseAsync();
            await tran.DisposeAsync();

            return fileStream;
        }
    }
}

//foreach (string path in imagePaths)
//{
//    string[] fileEntries = Directory.GetFiles(path);
//    byte[] photoByteArray;

//    foreach (string fileEntry in fileEntries)
//    {
//        using (FileStream stream = File.Open(fileEntry, FileMode.Open))
//        {
//            photoByteArray = new byte[stream.Length];
//            await stream.ReadAsync(photoByteArray, 0, (int)stream.Length);

//            using (SqlConnection connection = new SqlConnection(connStringBuilder.ToString()))
//            {

//                var command2 = dbContext.Database.GetDbConnection().CreateCommand();

//                command2.ExecuteReader();

//                connection.Open();
//                SqlCommand command = new SqlCommand("SELECT TOP(1) Photo.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() FROM employees", connection);

//                SqlTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
//                command.Transaction = tran;

//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        // Get the pointer for the file
//                        string path = reader.GetString(0);
//                        byte[] transactionContext = reader.GetSqlBytes(1).Buffer;

//                        // Create the SqlFileStream
//                        using (Stream fileStream = new SqlFileStream(path, transactionContext, FileAccess.Read, FileOptions.SequentialScan, allocationSize: 0))
//                        {
//                            // Read the contents as bytes and write them to the console
//                            for (long index = 0; index < fileStream.Length; index++)
//                            {
//                                Console.WriteLine(fileStream.ReadByte());
//                            }
//                        }
//                    }
//                }
//                tran.Commit();
//            }
//        }
//    }
//}

