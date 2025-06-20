using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;
using AppStore.Domain.ViewModels;

namespace AppStore.Domain.Contracts
{
    public interface IProductGroupRepository
    {
        List<ProductGroupViewModels>? GroupList(int take = 10, int skip = 0);

    }
}
