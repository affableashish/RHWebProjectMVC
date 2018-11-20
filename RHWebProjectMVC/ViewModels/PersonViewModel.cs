using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RHWebProjectMVC.ViewModels
{
    public class PersonViewModel
    {

        [Required(ErrorMessage = "FirstName is Required. ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is Required. ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EmailAddress is Required. ")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "DateOfBirth is Required. ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}