using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.ViewModels
{
    public class CreatAccountViewModel
    {
       

        [Display(Name = "نام کاربری")]
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "رمز")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }= false;
        public bool IsActive { get; set; }=true;
        public bool IsDelete { get; set; } = false;
        public string ActiveCode { get; set; } = "12345";

    }
}
