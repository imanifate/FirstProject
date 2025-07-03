using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.Models
{
    public class ProductGallery:BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
