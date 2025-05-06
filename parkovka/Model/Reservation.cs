using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class Reservation ///бронирование
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Дата начала бронирования обязательна.")]
        public required DateTime StartDate { get; set; } ///дата и время въезда

        [Required(ErrorMessage = "Дата окончания бронирования обязательна.")]
        public required DateTime EndDate { get; set; } ///дата и время выезда
        public int SpotId { get; set; }
        public ParkingSpot ReservedSpot { get; set; } ///информация о парковочном месте
    }
}
