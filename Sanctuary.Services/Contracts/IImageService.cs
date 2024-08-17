using Microsoft.Data.SqlClient;

namespace Sanctuary.Services.Contracts
{
    public interface IImageService
    {
        Task<Stream?> GetProfileImageByPk(string picturePk);
    }
}
