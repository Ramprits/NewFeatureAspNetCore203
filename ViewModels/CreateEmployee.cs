using System;
using System.ComponentModel.DataAnnotations;

namespace NewFeatureApplication.ViewModels {
    public class CreateEmployee {
        [Required (ErrorMessage = "You must enter first name"), MaxLength (25), MinLength (5)]
        public string FirstName { get; set; }
        [Required (ErrorMessage = "You must enter last name"), MaxLength (25), MinLength (5)]
        public string LastName { get; set; }
        [Required (ErrorMessage = "You must enter email")]
        public string Email { get; set; }
        [Required (ErrorMessage = "You must enter mobile number")]
        public string Mobile { get; set; }
        public Guid DepartmentId { get; set; }
    }
}