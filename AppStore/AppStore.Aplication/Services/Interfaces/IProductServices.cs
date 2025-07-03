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
        List<ProductViewModels>? GetAll(int take=10 , int skip=0);
        ProductViewModels? GetDetailsById(int id);
        ResultCreatProduct Create(CreatProductViewModel creatProductViewModel);
 
    }
}
