using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.ViewModels
{
    public class ListAccountViewModels
    {
        public int AccountId { get; set; }
     
        [MaxLength(100)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }   

        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }

       public DateTime CreatDate { get; set; }  
        public bool IsAdmin { get; set; }
       public bool IsDelete {  get; set; }
       public bool IsActive {  get; set; }

    }
}
