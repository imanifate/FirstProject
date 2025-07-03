using AppStore.Aplication.Services.Implements;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Data.Context;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductSubGroupController(IProductSubGroupServices productSubGroupServices) : Controller
    {

        [HttpGet("SubGroupProduct")]
        public IActionResult SubGroupList(int id)
        {

            var productSubGroupListViewModels = productSubGroupServices.List(id);
            if(productSubGroupListViewModels==null)
                return NotFound();


            //    new ProductSubGroupListViewModels
            //{
            //    GroupId = id,
            //    SubGroups = productSubGroupServices.List(id)
            //};
            return View(productSubGroupListViewModels);
        }

        [HttpGet("subGroupCreat")]
        public IActionResult SubGroupCreat(int id)
        {
            CreatProductSubGroupViewModels creatProductSubGroupViewModels =  productSubGroupServices.GetForGropById(id);
            

            return View(creatProductSubGroupViewModels);
        }

        [HttpPost("subGroupCreat")]
        public IActionResult SubGroupCreat(CreatProductSubGroupViewModels creatProductSubGroupViewModels)
        {
            if(!ModelState.IsValid) return View(creatProductSubGroupViewModels);
          ResultCreatProductSubGroup result = productSubGroupServices.Creat(creatProductSubGroupViewModels);
            switch (result)
            {
                case ResultCreatProductSubGroup.Success:
                    ModelState.AddModelError("Success", "عنوان زیرگروه با موفقیت ثبت شد"); 
                    return RedirectToAction(nameof(SubGroupList), new { id = creatProductSubGroupViewModels.GroupId});

                case ResultCreatProductSubGroup.SubGroupTitelDuplicated: 
                    ModelState.AddModelError("Error", " عنوان زیرگروه وارد شده تکراری است");
                    break;


                default: 
                    ModelState.AddModelError("Error", "ثبت عنوان زیرگروه با خطا مواجه شد"); break;
            }

            return View(creatProductSubGroupViewModels);
        }

    }
}
