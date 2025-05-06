using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.DTOs.Auth
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Электронная почта обязательна для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
