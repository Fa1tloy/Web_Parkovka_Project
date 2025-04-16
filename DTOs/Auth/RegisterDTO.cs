using System.ComponentModel.DataAnnotations;
namespace Web_Parkovka_Project.DTOs.Auth
{
    public class RegisterDTO
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? Patronymic { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
