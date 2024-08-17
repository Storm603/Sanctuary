using System.Data;
using Microsoft.Data.SqlClient;
using Sanctuary.Common;
using Sanctuary.Data.Models.PicturesTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Contracts;

namespace Sanctuary.Services
{
    public class ImageService : IImageService
    {
        public IImageRepository<ImageStorage> imageRepository { get; set; }
        public ImageService(IImageRepository<ImageStorage> injRepo)
        {
            this.imageRepository = injRepo;
        }

        public async Task<Stream?> GetProfileImageByPk(string pictureId)
        {
            SqlCommand command = new SqlCommand(TSQLStatements.ReadFilestreamDataByPkFromPictureStorage);

            return await imageRepository.GetImageByPk(pictureId, command);
        }
    }
}
