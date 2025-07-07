using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Enums;
using AppStore.Domain.ViewModels;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace AppStore.Aplication.Services.Interfaces
{
    public interface IProductServices
    {
        ProductListViewModels? ProductList(int SubGroupId);
        ProductViewModels? GetDetailsById(int id);
        ResultCreatProduct Create(CreatProductViewModel creatProductViewModel);
        CreatProductViewModel GetSubGroupById(int id);



    }
}
