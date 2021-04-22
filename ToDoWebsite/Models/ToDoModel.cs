using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ToDoWebsite.Models
{
    public class ToDoModel
    {
        [Key]
        [HiddenInput]
        public int ToDoModelId { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public String UserEmail { get; set; }

        [Required]
        [StringLength(100)]
        public String Title { get; set; }

        [StringLength(1000)]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AddedDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public Boolean Done { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DoneDate { get; set; }


        public ToDoModel()
        {
        }
    }
}

