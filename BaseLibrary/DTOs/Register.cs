using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs;

public class Register : AccountBase
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string? Fullname { get; set; }
    
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    [Required(ErrorMessage = "Password is required")]
    public string? ConfirmPassword { get; set; }
    
}