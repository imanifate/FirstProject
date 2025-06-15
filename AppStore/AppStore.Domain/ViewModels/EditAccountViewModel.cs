using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AppStore.Domain.ViewModels
{
    public class EditAccountViewModel
    {
       public int AccountId { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "تاریخ  ویرایش")]
        public DateTime ModifiedDate { get; set; }=DateTime.Now;
        public bool IsAdmin { get; set; }= false;
        public bool IsActive { get; set; }=true;
        public bool IsDelete { get; set; } = false;
        

    }
}
