using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Models
{
    public class BlogModel
    {
        [Key]
        [HiddenInput]
        [Required]
        public String BlogID { get; set; }

        [Required]
        [StringLength(100)]
        public String Title { get; set; }

        [Required]
        [StringLength(5000)]
        public String Content { get; set; }

        [ForeignKey("AuthorModel")]
        [Required]
        public AuthorModel AuthorID { get; set; }

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
