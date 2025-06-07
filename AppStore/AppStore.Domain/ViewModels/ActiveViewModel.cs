using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.ViewModels
{
    public class ActiveViewModel
    {
        [Display(Name = "کد فعال سازی")]
        [MaxLength(6)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ActiveCode { get; set; }
    }
}
