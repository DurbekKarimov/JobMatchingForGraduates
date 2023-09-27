﻿using System.ComponentModel.DataAnnotations;

namespace JobMatchingForGraduates.Service.DTOs.Students;

public class StudentForCreationDto
{
    [Required(ErrorMessage = "Enter the FirstName")]

    public string FirstName { get; set; }

    [Required(ErrorMessage = "Enter the LastName")]

    public string LastName { get; set; }

    [EmailAddress(ErrorMessage = "Enter properly")]

    public string Email { get; set; }

    [Required(ErrorMessage = "Enter the password")]

    public string Password { get; set; }

    [Required(ErrorMessage = "Enter the Phone Number")]

    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Enter the Direction")]

    public string Direction { get; set; }
}
