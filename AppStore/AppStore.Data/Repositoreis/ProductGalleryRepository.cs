using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Data.Context;
using AppStore.Domain.Contracts;
using AppStore.Domain.Models;

namespace AppStore.Data.Repositoreis
{
    public class ProductGalleryRepository(AppStore_DB_Context appStore_DB_Context) : IProductGalleryRepository
    {
        public void Creat(ProductGallery productGallery)
        {
            appStore_DB_Context.ProductGalleries.Add(productGallery);
        }

        public void Delete(ProductGallery productGallery)
        {
            
        }

        public void Edit(ProductGallery productGallery)
        {
            appStore_DB_Context.ProductGalleries.Update(productGallery);

        }

        public void Save()
        {
            appStore_DB_Context.SaveChanges();

        }
    }
}
