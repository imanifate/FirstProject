using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.ViewModels
{
    public class ResetPasswordViewMdel
    {
        [Display(Name = "کد فعال سازی")]
        [MaxLength(6)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ActiveCode { get; set; }


        [Display(Name = " پسورد")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }


        [Display(Name = " تکرار پسورد")]
        [MaxLength(200)]
        [Compare("Password")]
        [Required(ErrorMessage = "لطفا پسورد را مجدد وارد کنید")]
        public string RePassword { get; set; }

    }
}
