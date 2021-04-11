using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Models
{
    public class BlogModel
    {
        [Required]
        [StringLength(100)]
        public String Title { get; set; }

        [Required]
        [StringLength(5000)]
        public String Content { get; set; }


        [Required]
        public AuthorModel Author { get; set; }


        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }


        public BlogModel()
        {
        }




    }
}
