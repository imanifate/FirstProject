using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;

namespace AppStore.Aplication.Services.Interfaces
{
    public interface IProductSubGroupServices
    {
        ProductSubGroupListViewModels? List(int id);

        ResultCreatProductSubGroup Creat(CreatProductSubGroupViewModels creatProductSubGroupViewModels);
        CreatProductSubGroupViewModels? GetForGropById(int id);
        EditProductGroupViewModels GetForEdit(int id);

        ResultEditProductGroup Edit(EditProductGroupViewModels editProductGroupViewModels);


    }
}
