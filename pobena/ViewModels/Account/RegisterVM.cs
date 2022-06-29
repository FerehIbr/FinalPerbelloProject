using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.ViewModels.Account
{
    public class RegisterVM
    {
        [MaxLength(255), Required]
        public string FullName { get; set; }
        [MaxLength(255), Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string RepeatYourPassword { get; set; }
        public bool SubscribeOurNewsletter { get; set; }
    }
}
