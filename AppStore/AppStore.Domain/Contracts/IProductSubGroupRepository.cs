using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Domain.Contracts
{
    public interface IProductSubGroupRepository
    {
        ProductSubGroupListViewModels? List(int id);
        void Creat(ProductSubGroup productSubGroup);
        ProductGroup GetForGropById(int id);
        void Save();
        bool ExistSubGroupTitel(string subGroupTitel , int groupId);
        ProductGroup GetById(int id);
        void EditProductGroup(ProductGroup productGroup);
        bool DoplicateGroupTitel(EditProductGroupViewModels editProductGroupViewModels);

        bool Exist(int id);


    }
}
