using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Domain.Contracts;
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
    }
}
