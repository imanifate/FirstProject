using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Domain.Models
{
    public class Account : BaseEntity
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(100)]
        [Required]
        public string UserName {get; set;}

        [Display(Name = "رمز")]
        [MaxLength(200)]
        [Required]
        public string Password {get; set;}

        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required]
        public string Email {get; set;}

        public bool IsDelete { get; set; } = false; 
        public bool IsAdmin { get; set; }=false;
        public bool IsActive { get; set; }=false;
        public bool Rules { get; set; }=true;
        public string? ActiveCode { get; set; }

    }
}
