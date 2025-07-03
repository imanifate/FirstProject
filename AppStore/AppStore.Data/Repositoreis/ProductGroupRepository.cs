using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Data.Context;
using AppStore.Domain.Contracts;
using AppStore.Domain.Enums;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Data.Repositoreis
{
    public class ProductGroupRepository(AppStore_DB_Context appStore_DB_Context) : IProductGroupRepository
    {
        public List<ProductGroupViewModels>? GroupList(int take = 10, int skip = 0)
        {
            return appStore_DB_Context.ProductGroups
                .Select(c => new ProductGroupViewModels()
            {
                GroupId = c.Id,
                GroupTitel = c.GroupTitel,
                CreatDate = c.CreatDate,
                ModifiedDate = c.ModifiedDate,
                ProductCount = 0,
                IsDelete = c.IsDeleted
            }).Take(take).Skip(skip).ToList();
          
        }
        public void Creat(ProductGroup productGroup)
        {
            appStore_DB_Context.Add(productGroup);
           
        }
        public bool ExistGroupTitel(string groupTitel)
        {
            return appStore_DB_Context.ProductGroups.Any(p =>  p.GroupTitel == groupTitel);
        }
        public bool DoplicateGroupTitel(EditProductGroupViewModels editProductGroupViewModels)
        {
            return appStore_DB_Context.ProductGroups
                .Any(p => p.GroupTitel == editProductGroupViewModels.GroupTitel 
                       && p.Id == editProductGroupViewModels.GroupId);
        }

        public ProductGroup GetById(int id)
        {
            return appStore_DB_Context.ProductGroups.FirstOrDefault(i => i.Id == id);
        }

        
        public void EditProductGroup(ProductGroup productGroup)
        {
            appStore_DB_Context.Update(productGroup);
        }

        public void Save()
        {
            appStore_DB_Context.SaveChanges();
        }
        public bool Exist(int id)
        {
            return appStore_DB_Context.ProductGroups.Any(i => i.Id == id);
        }
    }
}
