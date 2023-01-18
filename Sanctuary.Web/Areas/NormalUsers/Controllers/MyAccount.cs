using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sanctuary.Web.Areas.NormalUsers.Controllers
{
    [Authorize(Roles = "User")]
    public class MyAccount : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("/Areas/NormalUsers/Views/Index.cshtml");
        }
    }
}
