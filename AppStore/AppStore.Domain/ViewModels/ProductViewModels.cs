using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;

namespace AppStore.Domain.ViewModels
{
    public class ProductViewModels
    {
        public int ProductId { get; set; }
      
        public string Titel { get; set; }
       
        public string ShortDescription { get; set; }
    
        public string Description { get; set; }

        public int Price { get; set; }
      
        public string? ImageName { get; set; }
    
        public string tag { get; set; }
       
        public string Visit { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
