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

        //Navigation Property
        //public List<ProductSubGroup> SubGroups { get; set; }

        public List<ProductSubGroup>? ProductSubGroups { get; set; }
        public List<Product> Products { get; set; }
    }
    public class ProductSubGroup:BaseEntity
    {
        [Display(Name ="عنوان زیر گروه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(200)]
        public int GroupId { get; set; }
        public string SubGroupTitel { get; set; }

        [ForeignKey("GroupId")]
        public ProductGroup? ProductGroup { get; set; }
        public List<Product> Products { get;  set; }

    }
}
