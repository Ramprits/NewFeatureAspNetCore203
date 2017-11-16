using System;
using NewFeatureApplication.Models;

namespace NewFeatureApplication.ViewModels {
    public class EmployeeVm {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Department Department { get; set; }
    }
}