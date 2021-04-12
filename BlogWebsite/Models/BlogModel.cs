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
        public int BlogModelId { get; set; }

        [ForeignKey("AuthorModel")]
        [Required]
        public String AuthorEmail { get; set; }

        [Required]
        public String AuthorName { get; set; }

        [Required]
        [StringLength(100)]
        public String Title { get; set; }

        [Required]
        [StringLength(5000)]
        public String Content { get; set; }


        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }


        public BlogModel()
        {
        }




    }
}
