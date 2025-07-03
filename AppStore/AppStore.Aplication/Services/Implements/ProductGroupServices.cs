using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Contracts;
using AppStore.Domain.Enums;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Aplication.Services.Implements
{
    public class ProductGroupServices(IProductGroupRepository productGroupRepository): IProductGroupServices
    {
        public List<ProductGroupViewModels>? GroupList(int take =10 , int skip=0)
        {
          return  productGroupRepository.GroupList(take , skip);
          
        }
        public ResultCreatProductGroup Creat(CreatProductGroupViewModels creatProductGroupViewModels)
        {
            if (productGroupRepository.ExistGroupTitel(creatProductGroupViewModels.GroupTitel)) return ResultCreatProductGroup.GroupTitelDuplicated;
            productGroupRepository.Creat(new ProductGroup
            {
                GroupTitel = creatProductGroupViewModels.GroupTitel,
                CreatDate = DateTime.Now,
                ModifiedDate = null,
                IsDeleted = false,

            });
            productGroupRepository.Save();
            return ResultCreatProductGroup.Success;
        }
        public EditProductGroupViewModels GetForEdit(int id)
        {
            ProductGroup productGroup = productGroupRepository.GetById(id);
            if (productGroup == null) return null;
            return new EditProductGroupViewModels()
            {
                GroupTitel = productGroup.GroupTitel,
                IsDeleted = productGroup.IsDeleted,
                GroupId = productGroup.Id
            };
        }

        public ResultEditProductGroup Edit(EditProductGroupViewModels editProductGroupViewModels)
        {
            ProductGroup productGroup = productGroupRepository.GetById(editProductGroupViewModels.GroupId);
            if (productGroup == null) return ResultEditProductGroup.Null;
            
            productGroup.GroupTitel = editProductGroupViewModels.GroupTitel;
            productGroup.IsDeleted = editProductGroupViewModels.IsDeleted;
            productGroup.ModifiedDate = editProductGroupViewModels.ModifiedDate;
            productGroupRepository.EditProductGroup(productGroup);
            productGroupRepository.Save();
            return ResultEditProductGroup.Success;
        }
        public ResultDeletProductGroup Delete(int id)
        {
            ProductGroup productGroup = productGroupRepository.GetById(id);
            if(productGroup == null) return ResultDeletProductGroup.Null;
            productGroup.IsDeleted = true;
            productGroupRepository.EditProductGroup(productGroup);
            productGroupRepository.Save();
            return ResultDeletProductGroup.Success;
        }
    }
}
