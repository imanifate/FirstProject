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
    public class ProductSubGroupRepository(AppStore_DB_Context appStore_DB_Context) : IProductSubGroupRepository
    {
        public ProductSubGroupListViewModels? List(int id)
        {
            ProductGroup productGroup = appStore_DB_Context.ProductGroups.FirstOrDefault(i => i.Id == id);
            if(productGroup==null)
                return null;

            var SubGroups = appStore_DB_Context.ProductSubGroups
              .Where(c => c.GroupId == id)
              .Select(c => new ProductSubGroupViewModels()
              {

                  Id = c.Id,
                  SubGroupTitel = c.SubGroupTitel,
                  CreatDate = c.CreatDate,
                  ModifiedDate = c.ModifiedDate,
                  ProductCount = 0
              }).ToList();
            return new ProductSubGroupListViewModels()
            {
                GroupId = productGroup.Id,
                GroupTitel = productGroup.GroupTitel,
                SubGroups = SubGroups
            };
        }
        public void Creat(ProductSubGroup productSubGroup)
        {
            appStore_DB_Context.Add(productSubGroup);

        }
        public ProductGroup GetForGropById(int id)
        {
            return appStore_DB_Context.ProductGroups
                .Where(sg => sg.Id == id)
                .FirstOrDefault();
        }
        public bool ExistSubGroupTitel(string subGroupTitel, int groupId)
        {
            return appStore_DB_Context.ProductSubGroups.Any(p => p.SubGroupTitel == subGroupTitel && p.GroupId == groupId);
        }
        public bool DoplicateGroupTitel(EditProductGroupViewModels editProductGroupViewModels)
        {
            return appStore_DB_Context.ProductGroups.Any(p => p.GroupTitel == editProductGroupViewModels.GroupTitel && p.Id == editProductGroupViewModels.GroupId);
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

        //public ProductSubGroup GetById(int id)
        //{
        //    var result= appStore_DB_Context.ProductSubGroups
        //        .Include(i=>i.ProductGroup)
        //        .FirstOrDefault(i=>i.Id== id);


        //}
    }
}
