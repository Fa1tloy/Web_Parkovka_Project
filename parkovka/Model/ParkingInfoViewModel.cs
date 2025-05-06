// Models/ParkingInfoViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Models
{
    public class ParkingInfoViewModel
    {
        // Vehicle properties
        [Required(ErrorMessage = "Марка транспортного средства обязательна")]
        [StringLength(100, ErrorMessage = "Марка не должна превышать 100 символов")]
        public string VehicleMake { get; set; }

        [Required(ErrorMessage = "Модель транспортного средства обязательна")]
        [StringLength(100, ErrorMessage = "Модель не должна превышать 100 символов")]
        public string VehicleModel { get; set; }

        [Required(ErrorMessage = "Номерной знак обязателен")]
        [RegularExpression(@"^[A-Z]\d{5}$", ErrorMessage = "Номерной знак должен быть формата A12345")]
        public string VehicleLicensePlate { get; set; }

        // ParkingSpot properties
        [Required(ErrorMessage = "Номер места обязателен")]
        [Range(1, 9999, ErrorMessage = "Номер места должен быть от 1 до 9999")]
        public int ParkingSpotNumber { get; set; }

        // User properties
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        public string UserSurname { get; set; }

        [StringLength(50, ErrorMessage = "Отчество не должно превышать 50 символов")]
        public string UserPatronymic { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Телефон обязателен")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        public string UserPhone { get; set; }
    }
}
