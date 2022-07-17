using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BookStore.Models
{
    public class BookModel
    {

        public int ID { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="Please Enter The Title of your Book")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]

        [StringLength(500, MinimumLength = 10)]

        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Language {get; set;}
        [Required]
        [Display(Name ="TotalPages Of Book")]
        public int? TotalPages { get; set;}
     

    }
}
