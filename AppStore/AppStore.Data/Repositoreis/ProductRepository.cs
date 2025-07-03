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

        public List<ProductViewModels>? GetAll(int take = 10, int skip = 0)
        {
            return appStore_BD_Contetxt.Products
                .Include(p => p.ProductGroup)
                .Include(p => p.ProductSubGroup)
                .Select(x => new ProductViewModels()
            {
               Id = x.Id,
               Titel = x.Titel,
               ShortDescription = x.ShortDescription,
               Description = x.Description,
               Price = x.Price,
               ImageName = x.ImageName,
               tag = x.tag,
               Visit = x.Visit,
               CreatDate = x.CreatDate,
               ModifiedDate = x.ModifiedDate,
               Group =  x.ProductGroup,
               SubGroup = x.ProductSubGroup
            })
                .Take(take)
                .Skip(skip)
                .ToList();
        }

        public List<ProductViewModels> GetByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Product? GetById(int id)
        {
            return appStore_BD_Contetxt.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<ProductViewModels> GetBySubGroupId(int SubgroupId)
        {
            throw new NotImplementedException();
        }

        
        public void Save()
        {
            appStore_BD_Contetxt.SaveChanges();
        }
    }
}
