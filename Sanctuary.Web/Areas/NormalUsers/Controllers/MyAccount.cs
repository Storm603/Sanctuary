using Microsoft.AspNetCore.Mvc;

namespace Sanctuary.Web.Areas.NormalUsers.Controllers
{
    public class MyAccount : Controller
    {
        public IActionResult Index()
        {
            return View("/Areas/NormalUsers/Views/Index.cshtml");
        }
    }
}
