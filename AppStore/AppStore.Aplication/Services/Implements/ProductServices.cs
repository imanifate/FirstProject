using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Data.Repositoreis;
using AppStore.Domain.Contracts;
using AppStore.Domain.Enums;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Aplication.Services.Implements
{
    public class ProductServices 
        (IProductRepository productRepository
        ,IProductGalleryRepository productGalleryRepository
        ,IProductGroupRepository productGroupRepository)
        : IProductServices
    {
        public List<ProductViewModels>? GetAll(int take = 10, int skip = 0)
        {
            return productRepository.GetAll(take, skip);
        }

        public ProductViewModels? GetDetailsById(int id)
        {
            Product product = productRepository.GetById(id);
            if (product == null) return null;
            return new ProductViewModels()
            {
                Id = product.Id,
                Titel = product.Titel,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Price = product.Price,
                ImageName = product.ImageName,
                tag = product.tag,
                Visit = product.Visit,
                CreatDate = product.CreatDate,
                ModifiedDate = product.ModifiedDate,
                Group = product.ProductGroup,
                SubGroup = product.ProductSubGroup
            };
        }

       public ResultCreatProduct Create(CreatProductViewModel creatProductViewModel)
       {
            if (productGroupRepository.Exist(creatProductViewModel.GroupId))
                return ResultCreatProduct.GroupNotFound;

            //if (productSubGroupRepository.Exist(creatProductViewModel.GroupId))
            //    return ResultCreatProduct.GroupNotFound;


            Product product = new Product
            {
                
                Titel = creatProductViewModel.Titel,
                ShortDescription = creatProductViewModel.ShortDescription,
                Description = creatProductViewModel.Description,
                Price = creatProductViewModel.Price,
                ImageName = "noimage.jpg",
                tag = creatProductViewModel.tag,
                Visit = creatProductViewModel.Visit,
                ModifiedDate = null,
                IsDeleted = false,
                GroupId = creatProductViewModel.GroupId,
                SubGroupId = creatProductViewModel.SubGroupId
            };
            if (creatProductViewModel.Image != null)
            {
                product.ImageName = Guid.NewGuid().ToString() + 
                    Path.GetExtension(creatProductViewModel.Image.FileName);

                string SavePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/ProductImages", product.ImageName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                     creatProductViewModel.Image.CopyTo(stream);
                }
            }

            productRepository.Add(product);
            productRepository.Save();

            if(creatProductViewModel.ImgGalleries != null && creatProductViewModel.ImgGalleries.Any())
            {
                foreach (var img in creatProductViewModel.ImgGalleries)
                {
                    string imagName = Guid.NewGuid().ToString() +
                        Path.GetExtension(img.FileName);
                    string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/ProductImages", imagName);
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        img.CopyTo(stream);
                    }


                    ProductGallery gallery = new ProductGallery()
                    {
                        CreatDate = DateTime.Now,
                        ImageName = imagName,
                        IsActive = true,
                        ProductId = product.Id,
                        IsDeleted = false

                    };
                    productGalleryRepository.Creat(gallery);
                }
                productGalleryRepository.Save();
            }
         
            return ResultCreatProduct.Success;
       }

    }
}
