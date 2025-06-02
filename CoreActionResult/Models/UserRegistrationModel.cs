﻿using System.ComponentModel.DataAnnotations;

namespace CoreActionResult.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        public bool RememberMe { get; set; }
        [Required(ErrorMessage = "Please slect a course")]
        public string SlectedCourse { get; set; }
        public List<string> Courses { get; set; }
        [Required(ErrorMessage = "Please select one or more skills")]
        public List<string> Skills { get; set; }
        public Guid HiddenFiled { get; set; }
    }
}
