using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppStore.Domain.ViewModels
{
    public class LoginAccountViewModel
    {
        [Display(Name = "نام کاربری یا ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserNameOrEmail { get; set; }




        [Display(Name = " پسورد")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }


        public bool RememberMe { get; set; }

    }
}
