using System.Collections.Generic;
using AppStore.Aplication.Services.Implements;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Contracts;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.Admin.Controllers
{
    public class ProductController
        (IProductServices productServices) : Controller
    {
        [Area("Admin")]
        [HttpGet("ProductList")]
        public IActionResult ProductList()
        {
           List<ProductViewModels> productViewModels = productServices.GetAll(int.MaxValue);

            return View(productViewModels);
        }

       

        [HttpGet("ProductDetails")]
        public IActionResult Detail(int id)
        {
         ProductViewModels productViewModels = productServices.GetDetailsById(id);
            return View(productViewModels);
        }

        [HttpGet("CreatProduct")]
        public IActionResult Creat()
        {
            return View();
        }

        [HttpPost("CreatProduct")]
        public IActionResult Creat(CreatProductViewModel creatProductViewModel)
        {
            if(!ModelState.IsValid)  return View(creatProductViewModel);

            ResultCreatProduct result = productServices.Create(creatProductViewModel);
            switch (result)
            {
                case ResultCreatProduct.Success: ModelState.AddModelError("Success", "ثبت محصول با موفقیت انجام شد"); return RedirectToAction(nameof(ProductList));
                case ResultCreatProduct.GroupNotFound: ModelState.AddModelError("Error", "گروه محصول یافت نشد"); break;
                case ResultCreatProduct.SubGroupNotFound: ModelState.AddModelError("Error", "زیر گروه محصول یافت نشد"); break;
                default: ModelState.AddModelError("Error", "ثبت محصول با خطا مواجه شد"); break;
            }

            return View(creatProductViewModel);
        }
    }
}
