using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Data.Context;
using AppStore.Domain.Enums;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Domain.Contracts
{
    public class ProductRepository(AppStore_DB_Context appStore_BD_Contetxt) : IProductRepository
    {
        public void Add(Product Product)
        {
            appStore_BD_Contetxt.Products.Add(Product);
        }

        public void Edit(Product Product)
        {
            appStore_BD_Contetxt.Products.Update(Product);

        }

        public ProductListViewModels? ProductList(int SubGroupId)
        {
            ProductSubGroup? productSubGroup = appStore_BD_Contetxt.ProductSubGroups
                .FirstOrDefault(sg => sg.Id == SubGroupId);
            if(productSubGroup == null)
                return null;

            List<ProductViewModels> products = appStore_BD_Contetxt.Products
                .Where(p => p.SubGroupId == SubGroupId)
                .Select(p => new ProductViewModels()
                {
                   
                    Titel = p.Titel,
                    ShortDescription = p.ShortDescription,
                    Description = p.Description,
                    Price = p.Price,
                    ImageName = p.ImageName,
                    tag = p.tag,
                    Visit = p.Visit,
                    CreatDate = p.CreatDate,
                    ModifiedDate = p.ModifiedDate,
                   }).ToList();

            return new ProductListViewModels()
            {
                SubGroupId = productSubGroup.Id,
                SubGroupTitel = productSubGroup.SubGroupTitel,
                Products = products
            };
        }

        public Product? GetById(int id)
        {
            return appStore_BD_Contetxt.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            appStore_BD_Contetxt.SaveChanges();
        }

        public ProductSubGroup GetForSubGroupById(int id)
        {
          return  appStore_BD_Contetxt.ProductSubGroups
                .Where(p => p.Id == id)
                .FirstOrDefault();

        }

        
    }
}
