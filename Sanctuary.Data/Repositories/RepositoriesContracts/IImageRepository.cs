using Microsoft.Data.SqlClient;
using Sanctuary.Data.Models.PicturesTables;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IImageRepository<TPicture> : IBaseRepository<TPicture> where TPicture : ImageStorage
    {
        Task<Stream?> GetImageByPk(string picturePk, SqlCommand command);
    }
}
