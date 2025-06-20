using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Data.Context;
using AppStore.Domain.Contracts;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Data.Repositoreis
{
    public class ProductGroupRepository(AppStore_DB_Context appStore_DB_Context) : IProductGroupRepository
    {
        public List<ProductGroupViewModels>? GroupList(int take = 10, int skip = 0)
        {
            return appStore_DB_Context.ProductGroups.Select(c => new ProductGroupViewModels()
            {
                Id = c.Id,
                GroupId = 0,
                GroupTitel = c.GroupTitel,
                CreatDate = c.CreatDate,
                ModifiedDate = c.ModifiedDate,
                ProductCount = 0
            }).Take(take).Skip(skip).ToList();
          
        }
    }
}
