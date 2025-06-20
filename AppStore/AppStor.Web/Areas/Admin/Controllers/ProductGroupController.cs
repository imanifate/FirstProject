using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductGroupController(IProductGroupServices productGroupServices): Controller
    {
        [HttpGet("GroupProduct")]
        public IActionResult Index()
        {
          List<ProductGroupViewModels> productGroupViewModels = productGroupServices.GroupList(int.MaxValue);
            return View(productGroupViewModels);
        }
    }
}
