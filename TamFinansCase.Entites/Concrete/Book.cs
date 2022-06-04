using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.Entites.Abstract;

namespace TamFinansCase.Entites.Concrete
{
    public class Book : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order =1)]
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Kitap İsmi")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Kitap ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        public string BookName { get; set; }

        [Display(Name = "Yazar İsmi")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Yazar ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        public string WriterName { get; set; }
        public bool BookStatus { get; set; } = true;

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
