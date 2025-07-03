using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.ViewModels
{
    public class EditProductGroupViewModels
    {
        public int GroupId { get; set; }

        public string GroupTitel { get; set; }
        public bool IsDeleted { get;  set; }

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;



    }
}
