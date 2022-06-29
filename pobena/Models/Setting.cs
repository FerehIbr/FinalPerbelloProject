using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pobena.Models
{
    public class Setting : BaseEntity
    {
        public string Logo { get; set; }
       
        [StringLength(255), Required]
        public string Email { get; set; }
        [StringLength(255), Required]
        public string ContactEmail { get; set; }
        [StringLength(255), Required]
        public string Phone { get; set; }
        [StringLength(255), Required]
        public string Fax { get; set; }
        [StringLength(255), Required]
        public string Address { get; set; }
      
        [NotMapped]

        public IFormFile LogoImage { get; set; }
    }
}
