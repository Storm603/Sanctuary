using Microsoft.AspNetCore.Mvc;
using Sanctuary.Services.Contracts;

namespace Sanctuary.Web.Controllers
{
    [Area("NormalUsers")]
    public class ImageController : Controller
    {
        public IImageService ImageService { get; set; }

        public ImageController(IImageService ingImgService)
        {
            ImageService = ingImgService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPfpByPk(string pictureId)
        {
            if (string.IsNullOrWhiteSpace(pictureId))
            {
                return NoContent();
            }

            Stream? stream = await ImageService.GetProfileImageByPk(pictureId);

            if (stream == null)
            {
                return NotFound();
            }

            return File(stream, "image/png");
        }
    }
}
