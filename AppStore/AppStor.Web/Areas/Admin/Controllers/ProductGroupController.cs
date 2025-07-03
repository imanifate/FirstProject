using System.Collections.Generic;
using AppStore.Aplication.Services.Implements;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using AppStore.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.Admin.Controllers 
{
    [Area("Admin")]
    public class ProductGroupController(
        IProductGroupServices productGroupServices) : BaseController
    {
        [HttpGet("GroupList")]
        public IActionResult GroupList()
        {
          List<ProductGroupViewModels> productGroupViewModels = productGroupServices.GroupList(int.MaxValue);
            return View(productGroupViewModels);
        }

        [HttpGet("CreatGroup")]
        public IActionResult CreatGroup()
        {
            return View();
        }

        [HttpPost("CreatGroup")]
        public IActionResult CreatGroup(CreatProductGroupViewModels creatProductGroupViewModels)
        {
            if(!ModelState.IsValid) return View(creatProductGroupViewModels);

            ResultCreatProductGroup result = productGroupServices.Creat(creatProductGroupViewModels);
            switch (result)
            {
                case ResultCreatProductGroup.Success:
                    ModelState.AddModelError("Success", "عنوان گروه با موفقیت ثبت شد");
                    return RedirectToAction(nameof(GroupList));

                case ResultCreatProductGroup.GroupTitelDuplicated:
                    ModelState.AddModelError("Error", " عنوان گروه وارد شده تکراری است");
                    break;

                default: ModelState.AddModelError("Error", "ثبت عنوان گروه با خطا مواجه شد");
                    break;
            }
            return View();
        }

        [HttpGet("editGroup")]
        public IActionResult EditGroup(int id )
        {
           EditProductGroupViewModels editProductGroupViewModels = productGroupServices.GetForEdit(id);
            if (editProductGroupViewModels.GroupId == 0 || editProductGroupViewModels.GroupId == null)
                return NotFound();
                return View(editProductGroupViewModels); 
        }

        [HttpPost("editGroup")]
        public IActionResult EditGroup(EditProductGroupViewModels editProductGroupViewModels)
        {
            if (!ModelState.IsValid)
            {
                AlertMessage("فیلد های خالی را پرکنید", TitleAlert.خطا, IConeAlert.error);
                return View();
            }

            ResultEditProductGroup result = productGroupServices.Edit(editProductGroupViewModels);
            switch (result)
            {
                case ResultEditProductGroup.Success:
                    ModelState.AddModelError("Success", " ویرایش با موفقیت انجام شد");
                    return RedirectToAction(nameof(GroupList));

                case ResultEditProductGroup.GroupTitelDuplicated:
                    ModelState.AddModelError("Error", " عنوان گروه وارد شده تکراری است");
                    break;

                case ResultEditProductGroup.Null:
                    ModelState.AddModelError("Error", "  گروه وارد شده یافت نشد");
                    break;

                default: ModelState.AddModelError("Error", "ویرایش عنوان گروه با خطا مواجه شد"); 
                    break;
            }
            return View(editProductGroupViewModels);
        }

        public IActionResult DeleteGroup(int id)
        {
            if(id == 0 || id == null) return NotFound();

            ResultDeletProductGroup result = productGroupServices.Delete(id);
            switch (result)
            {
                case ResultDeletProductGroup.Success:
                    ModelState.AddModelError("Success", " حذف با موفقیت انجام شد");
                    return RedirectToAction(nameof(GroupList));

                case ResultDeletProductGroup.Null:
                    ModelState.AddModelError("Error", "  گروه وارد شده یافت نشد");
                    break;

                default: ModelState.AddModelError("Error", " حذف گروه با خطا مواجه شد");
                    break;
            }

            return View();
        }


    }
}
