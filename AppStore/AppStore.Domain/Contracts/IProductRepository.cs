using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Enums;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Domain.Contracts
{
    public interface IProductRepository
    {
        void Add(Product Product);
        void Save();
        Product? GetById(int Id);
        void Edit(Product Product);
         
        List<ProductViewModels>? GetAll(int tak=10 ,int skip=0);
        List<ProductViewModels> GetByGroupId(int groupId);
        List<ProductViewModels> GetBySubGroupId(int SubgroupId);
        
    }
}
