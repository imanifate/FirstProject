using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using AppStore.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserAccountController(IAccountServices accountServices) : BaseController
    {
        [HttpGet("AccountList")]
        public IActionResult List()
        {
            List<ListAccountViewModels> list = accountServices.List();
            return View(list);
        }


        [HttpGet("Creat")]
        public IActionResult Creat()
        {
            return View();
        }

        [HttpPost("Creat")]
        public IActionResult Creat(CreatAccountViewModel creatAccountByAdminViewModel)
        {
            if(!ModelState.IsValid) return View(creatAccountByAdminViewModel);
         ResultCreatAccount result = accountServices.Creat(creatAccountByAdminViewModel);
            switch (result)
            {
                case ResultCreatAccount.Success: ModelState.AddModelError("Success", "ثبت نام با موفقیت انجام شد"); return RedirectToAction(nameof(List));
                case ResultCreatAccount.UsreNameDuplicated: ModelState.AddModelError("Error", "نام کاربری وارد شده تکراری است"); break;
                case ResultCreatAccount.EmailDuplicated: ModelState.AddModelError("Error", "ایمیل وارد شده تکراری است"); break;
                case ResultCreatAccount.Error: ModelState.AddModelError("Error", "ثبت نام با خطا مواجه شد"); break;
                default: ModelState.AddModelError("Error", "ثبت نام با خطا مواجه شد"); break;
            }
            return View();
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            EditAccountViewModel editAccountViewModel = accountServices.GetByIdForEdit(id);
            return View(editAccountViewModel);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(EditAccountViewModel editAccountViewModel)
        {
            if(!ModelState.IsValid) return View(editAccountViewModel);
            ResultEditAccount result = accountServices.Edit(editAccountViewModel);
            switch (result)
            {
                case ResultEditAccount.Success: ModelState.AddModelError("Success", " ویرایش با موفقیت انجام شد"); return RedirectToAction(nameof(List));
                case ResultEditAccount.UsreNameDuplicated: ModelState.AddModelError("Error", "نام کاربری وارد شده تکراری است"); break;
                case ResultEditAccount.EmailDuplicated: ModelState.AddModelError("Error", "ایمیل وارد شده تکراری است"); break;
                case ResultEditAccount.Error: ModelState.AddModelError("Error", " ویرایش با خطا مواجه شد"); break;
                default: ModelState.AddModelError("Error", " ویرایش با خطا مواجه شد"); break;
            }

            return View(editAccountViewModel);
        }

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return View(nameof(List));
            ResultDeleteAccount result = accountServices.Delete(id);
            switch (result)
            {
                case ResultDeleteAccount.Success: ModelState.AddModelError("Success", " حذف با موفقیت انجام شد"); return RedirectToAction(nameof(List));
                case ResultDeleteAccount.Null: ModelState.AddModelError("Error", " کاربر مورد نظر یافت نشد"); break;
                default: ModelState.AddModelError("Error", " حذف با خطا مواجه شد"); break;
            }
          return View(nameof(List));
        }

    }
}
