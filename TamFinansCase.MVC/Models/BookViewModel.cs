using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TamFinansCase.MVC.Models
{
    public class BookViewModel
    { 
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Kitap İsmi")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Kitap ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        public string BookName { get; set; }

        [Display(Name = "Yazar İsmi")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Yazar ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        public string WriterName { get; set; }
        public bool IsDeleted { get; set; } = false;

        
    }
}