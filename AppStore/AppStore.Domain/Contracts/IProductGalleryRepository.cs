using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;

namespace AppStore.Domain.Contracts
{
    public interface IProductGalleryRepository
    {
         void Creat(ProductGallery productGallery);
         void Save();
         void Edit(ProductGallery productGallery);
         void Delete(ProductGallery productGallery);

    }
}
