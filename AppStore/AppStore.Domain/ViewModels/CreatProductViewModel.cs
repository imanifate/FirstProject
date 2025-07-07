using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace AppStore.Domain.ViewModels
{
    public class CreatProductViewModel
    {
        [Display(Name = "عنوان کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string ProductTitel { get; set; }
        public string SubGroupTitel { get; set; }
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
        public IFormFile? Image { get; set; }

        [Display(Name = "تگ")]
        public string tag { get; set; } = "0";

        [Display(Name = "بازدید")]
        public string Visit { get; set; }

        [Display(Name = "گالری تصاویر")]
        public List<IFormFile>? ImgGalleries { get; set; }

    }
}
