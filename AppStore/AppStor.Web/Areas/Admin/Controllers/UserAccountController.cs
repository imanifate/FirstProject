using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using AppStore.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserAccountController(IUserAccountServices userAccountServices) : BaseController
    {
        [HttpGet("AccountList")]
        public IActionResult AccountList()
        {
            List<AccountListViewModels> accounts = userAccountServices.AccountList();
            return View(accounts);
        }


        [HttpGet("")]
        public IActionResult Creat()
        {
            return View();
        }
    }
}
