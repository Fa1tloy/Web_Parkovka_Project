using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class ParkingPlaces
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется указать номер автомобиля.")]
        [StringLength(10, ErrorMessage = "Номер не может быть длиннее 10 символов.")]
        public required string C_number { get; set; }

        [Required(ErrorMessage = "Требуется указать модель автомобиля.")]
        [StringLength(50, ErrorMessage = "Модель автомобиля не может быть длиннее 50 символов.")]
        public required string C_Model { get; set; }

        [Required(ErrorMessage = "Требуется указать модель автомобиля.")]
        [StringLength(50, ErrorMessage = "Модель автомобиля не может быть длиннее 50 символов.")]
        public required string C_Colour { get; set; }

        [Required(ErrorMessage = "Требуется указать владельца автомобиля.")]
        [StringLength(50, ErrorMessage = "Владелец автомобиля не может быть длиннее 50 символов.")]
        public required string C_owner { get; set; }
    }
}
