using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Номер парковочного места обязателен для заполнения.")]
        [Range(1,9999, ErrorMessage = "Номер парковочного места должен быть в диапазоне от 1 до 9999.")]
        public required int Number { get; set; } ///номер парковочного места
        public bool IsOccupied { get; set; } ///занятость
        public int VehicleId { get; set; }
        public Vehicle? OccupiedBy { get; set; } ///каждое парковочное место связано с конкретным транспортным средством, которое его занимает
    }
}
