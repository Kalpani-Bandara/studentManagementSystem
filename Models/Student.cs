using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Age is required")]
    [Range(5, 100, ErrorMessage = "Age must be between 5 and 100")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Course is required")]
    public string Course { get; set; } = string.Empty;
}