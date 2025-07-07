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
    public class ProductSubGroupServices(IProductSubGroupRepository productSubGroupRepository): IProductSubGroupServices    
    {
        public ProductSubGroupListViewModels? List(int id)
        {
            return productSubGroupRepository.List(id);           
        }

        public ResultCreatProductSubGroup Creat(CreatProductSubGroupViewModels creatProductSubGroupViewModels)
        {
            if (productSubGroupRepository.ExistSubGroupTitel(creatProductSubGroupViewModels.SubGroupTitel , creatProductSubGroupViewModels.GroupId)) 
                return ResultCreatProductSubGroup.SubGroupTitelDuplicated;
            productSubGroupRepository.Creat(new ProductSubGroup
            {
                SubGroupTitel = creatProductSubGroupViewModels.SubGroupTitel,
                GroupId = creatProductSubGroupViewModels.GroupId,
                CreatDate = DateTime.Now,
                ModifiedDate = null,
                IsDeleted = false,

            });
            
            productSubGroupRepository.Save();
            return ResultCreatProductSubGroup.Success;
        }
        public CreatProductSubGroupViewModels? GetForGropById(int id)
        {
            ProductGroup productGroup = productSubGroupRepository.GetForGropById(id);
            if (productGroup == null) return null;
            return new CreatProductSubGroupViewModels()
            {
                GroupId = productGroup.Id,
                GroupTitle = productGroup.GroupTitel
            };
        }
        public EditProductGroupViewModels GetForEdit(int id)
        {
            ProductGroup productGroup = productSubGroupRepository.GetById(id);
            if (productGroup == null) return null;
            return new EditProductGroupViewModels()
            {
                GroupTitel = productGroup.GroupTitel,
                IsDeleted = productGroup.IsDeleted
            };
        }

        public ResultEditProductGroup Edit(EditProductGroupViewModels editProductGroupViewModels)
        {
            ProductGroup productGroup = productSubGroupRepository.GetById(editProductGroupViewModels.GroupId);
            if (productGroup == null) return ResultEditProductGroup.Null;
            if(productSubGroupRepository.DoplicateGroupTitel(editProductGroupViewModels)) 
                return ResultEditProductGroup.GroupTitelDuplicated;
            productGroup.GroupTitel = editProductGroupViewModels.GroupTitel;
            productGroup.IsDeleted = editProductGroupViewModels.IsDeleted;
            productSubGroupRepository.EditProductGroup(productGroup);
            productSubGroupRepository.Save();
            return ResultEditProductGroup.Success;
        }
    }
}
