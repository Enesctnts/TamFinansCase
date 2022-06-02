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
    [Table("Categories")]
    public class Category : IEntity
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name ="Kategori İsmi")]
        [StringLength(maximumLength:30,MinimumLength =2,ErrorMessage ="Kategori ismi en az 2 en fazla 30 aralığında olmalıdır.")]
        public string CategoryName { get; set; }


        public virtual ICollection<Book> Books { get; set; }
    }
}
