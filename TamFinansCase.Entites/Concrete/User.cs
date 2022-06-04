using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.Entites.Abstract;

namespace TamFinansCase.Entites.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 2)]
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Password { get; set; }


    }
}
