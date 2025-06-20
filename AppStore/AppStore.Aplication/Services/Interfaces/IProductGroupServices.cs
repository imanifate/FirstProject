using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.ViewModels;

namespace AppStore.Aplication.Services.Interfaces
{
    public interface IProductGroupServices
    {
        List<ProductGroupViewModels>? GroupList(int take = 10, int skip = 0);

    }
}
