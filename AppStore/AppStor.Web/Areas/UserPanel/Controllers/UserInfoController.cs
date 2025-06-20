using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.UserPanel.Controllers
{
    public class UserInfoController : Controller
    {
        [Area("UserPanel")]
        public IActionResult CreatInfoUser(string userName)
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
