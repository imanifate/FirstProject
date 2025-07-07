using System.Collections.Generic;
using AppStore.Aplication.Services.Implements;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Contracts;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStor.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController
        (IProductServices productServices) : Controller
    {
        
        [HttpGet("productList")]
        public IActionResult ProductList(int id)
        {
           var productListViewModels = productServices.ProductList(id);
            if (productListViewModels == null)
                return NotFound();

            return View(productListViewModels);
        }

       

        [HttpGet("ProductDetails")]
        public IActionResult ProductDetails(int id)
        {
         ProductViewModels productViewModels = productServices.GetDetailsById(id);
            return View(productViewModels);
        }

        [HttpGet("productCreat")]
        public IActionResult ProductCreat(int id)
        {
           CreatProductViewModel creatProductViewModel =  productServices.GetSubGroupById(id);
            if (creatProductViewModel == null) return NotFound();
            return View(creatProductViewModel);
        }

        [HttpPost("productCreat")]
        public IActionResult ProductCreat(CreatProductViewModel creatProductViewModel)
        {
            if(!ModelState.IsValid)  return View(creatProductViewModel);

            ResultCreatProduct result = productServices.Create(creatProductViewModel);
            switch (result)
            {
                case ResultCreatProduct.Success: 
                    ModelState.AddModelError("Success", "ثبت محصول با موفقیت انجام شد");
                    return RedirectToAction(nameof(ProductList) , new {id = creatProductViewModel.SubGroupId});

                case ResultCreatProduct.GroupNotFound:
                    ModelState.AddModelError("Error", "گروه محصول یافت نشد");
                    break;

                case ResultCreatProduct.SubGroupNotFound:
                    ModelState.AddModelError("Error", "زیر گروه محصول یافت نشد"); 
                    break;

                default: ModelState.AddModelError("Error", "ثبت محصول با خطا مواجه شد");
                    break;
            }

            return View(creatProductViewModel);
        }
    }
}
