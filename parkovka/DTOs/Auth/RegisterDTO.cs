using System.ComponentModel.DataAnnotations;
namespace Web_Parkovka_Project.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения.")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов.")]
        public required string Surname { get; set; }

        [StringLength(50, ErrorMessage = "Отчество не должно превышать 50 символов.")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Электронная почта обязательна для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен для заполнения.")]
        [Phone(ErrorMessage = "Некорректный формат номера телефона.")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Подтверждение пароля обязательно.")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
