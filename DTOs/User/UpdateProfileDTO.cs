using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.DTOs.User
{
    public class UpdateProfileDTO
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        public string Surname { get; set; }

        [StringLength(50, ErrorMessage = "Отчество не должно превышать 50 символов")]
        public string? Patronymic { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Некорректный формат телефона")]
        public string PhoneNumber { get; set; }
    }
}
