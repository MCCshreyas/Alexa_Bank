//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Api_Alexa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string Phone_number { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Balance { get; set; }

        [Required(ErrorMessage = "Account number is required")]
        [Display(Name = "Account Number")]
        public string Account_number { get; set; }

        public string ImagePath { get; set; } = "";

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string BirthDate { get; set; }

        public int ID { get; set; }
    }
}
