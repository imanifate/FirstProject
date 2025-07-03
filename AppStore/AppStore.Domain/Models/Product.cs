using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.Models
{
    public class Product:BaseEntity
    {
        [Display(Name = "عنوان کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string Titel {  get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string ShortDescription { get; set; }
        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }
        [Display(Name = "تصویر")]
        public string? ImageName { get; set; }
        [Display(Name = "تگ")]
        public string tag {  get; set; }
        [Display(Name = "بازدید")]
        public string Visit {  get; set; }
        public List<ProductGallery> ProductGalleries { get; set; }
        [ForeignKey("ProductGroupId")]
        public ProductGroup ProductGroup { get; set; }
        [ForeignKey("ProductSubGroupId")]
        public ProductSubGroup ProductSubGroup { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

    }
}
