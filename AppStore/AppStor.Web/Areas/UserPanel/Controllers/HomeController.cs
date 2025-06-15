using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.UserPanel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePassword()
        { 
            return View();
        }
    }
}
