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
        public int UserId { get; set; }

        [Display(Name = "Kullanıcı İsmi")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Kullanıcı ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email İsmi")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Email ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        [EmailAddress(ErrorMessage ="Lütfen email adresini giriniz")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Email İsmi")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Kitap ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        public string Password { get; set; }


    }
}
