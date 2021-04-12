using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Models
{
    public class AuthorModel
    {
        
        //[HiddenInput]
        //public Guid AuthorModelId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(2, ErrorMessage = "First name must be atleast 2 alphabets")]
        [StringLength(25)]
        public String Given_Name { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(2, ErrorMessage = "Last name must be atleast 2 alphabets")]
        [StringLength(25)]
        public String Last_Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

        [Key]
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public String emailAddress { get; set; }

        [Url]
        public String WebsiteAddress { get; set; }

        [Phone]
        public String TelephoneNum { get; set; }

        public String Country { get; set; }

        public String province { get; set; }

        public String PostalCode { get; set; }


        public AuthorModel()
        {
          
        }
    }
}
