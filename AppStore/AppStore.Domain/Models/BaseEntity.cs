using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="تاریخ ایجاد")]
        public DateTime CreatDate { get; set; }= DateTime.Now;

        [Display(Name = "تاریخ ویرایش")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "حذف")]
        public  bool IsDeleted { get; set; }=false;
    }
}
