using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Models
{
    public class AuthorModel
    {
        
        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(2, ErrorMessage = "First name must be atleast 2 alphabets")]
        [StringLength(25)]
        public String Given_Name { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [MinLength(2, ErrorMessage = "Last name must be atleast 2 alphabets")]
        [StringLength(25)]
        public String Last_Name { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

        [Key]
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public EmailAddressAttribute emailAddress { get; set; }

        [Url]
        public String WebsiteAddress { get; set; }

        [Phone]
        public String TelephoneNum { get; set; }

        public String Country { get; set; }

        public String province { get; set; }

        public String PostalCode { get; set; }

        //private DateTime currentYear = DateTime.Now;

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (birthDate > currentYear)
        //    {
        //        yield return new ValidationResult(
        //            $"Birthday cannot be today's date.",
        //            new[] { nameof(birthDate) });
        //    }
        //}

        //[HttpPost]
        //public IActionResult Create(AuthorModel model)
        //{
        //    string message = "";

        //    if ()
        //    {
        //        message = "product " + model.Name + " created successfully";
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //    return Content(message);
        //}


        public AuthorModel()
        {
          
        }
    }
}
