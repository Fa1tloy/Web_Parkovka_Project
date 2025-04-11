using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class User ///пользователь, он же владелец транспортного средства
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов.")]
        public required string Name { get; set; } ///имя пользователя

        [Required(ErrorMessage = "Фамилия обязательна для заполнения.")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов.")]
        public required string Surname { get; set; } ///фамилия пользователя


        [StringLength(50, ErrorMessage = "Отчество не должно превышать 50 символов.")]
        public string Patronymic { get; set; } ///отчество пользователя

        [Required(ErrorMessage = "Электронная почта обязательна для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
        public string Email { get; set; } ///эл.почта пользователя

        [Required(ErrorMessage = "Номер телефона обязателен для заполнения.")]
        [Phone(ErrorMessage = "Некорректный формат номера телефона.")]
        public string PhoneNumber { get; set; } ///номер телефона пользователя

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); ///что каждый пользователь может владеть несколькими транспортными средствами
    }
}
