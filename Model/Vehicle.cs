using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class Vehicle ///транспортное средство
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Марка транспортного средства обязательна для заполнения.")]
        [StringLength(100, ErrorMessage = "Марка не должна превышать 100 символов.")]
        public required string Make { get; set; } ///марка транспортного средства

        [Required(ErrorMessage = "Модель транспортного средства обязательна для заполнения.")]
        [StringLength(100, ErrorMessage = "Модель не должна превышать 100 символов.")]
        public required string Model { get; set; } ///модель транспортного средства

        [Required(ErrorMessage = "Номерной знак обязателен для заполнения.")]
        [RegularExpression(@"^[A-Z]\d{5}$", ErrorMessage = "Номерной знак должен соответствовать формату: одна заглавная буква и пять цифр (пример: A12345).")]
        public required string LicensePlate { get; set; } ///номерной знак транспортного средства
        public int OwnerId { get; set; }
        public User Owner { get; set; } ///информация о владельце транспортного средства
    }
}
