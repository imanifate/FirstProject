using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.Models
{
    public class ProductGroup: BaseEntity
    {
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage ="لطفا{0} را وارد کنید")]
        public string GroupTitel {  get; set; }
        public List<ProductSubGroup>? ProductSubGroup { get; set; }
        
    }
    public class ProductSubGroup:BaseEntity
    {
        [Display(Name ="عنوان زیر گروه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int GroupId { get; set; }
        public string SubGroupTitel { get; set; }

        [ForeignKey("GroupId")]
        public ProductGroup? ProductGroup { get; set; }
    }
}
