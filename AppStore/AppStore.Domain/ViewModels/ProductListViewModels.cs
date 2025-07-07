using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;

namespace AppStore.Domain.ViewModels
{
    public class ProductListViewModels
    {
        public int SubGroupId { get; set; }

        public string SubGroupTitel { get; set; }

       public List<ProductViewModels> Products { get; set; }
       
    }
}
