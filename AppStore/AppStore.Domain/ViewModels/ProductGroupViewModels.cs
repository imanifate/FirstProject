using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.ViewModels
{
    public class ProductGroupViewModels
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
       public string GroupTitel { get; set; }
        public int? ProductCount { get; set; }

        public DateTime CreatDate { get; set; }

       public DateTime? ModifiedDate { get; set; }  
       public bool IsDelete {  get; set; }
  

    }
}
