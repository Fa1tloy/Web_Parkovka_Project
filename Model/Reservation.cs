namespace Web_Parkovka_Project.Model
{
    public class Reservation ///бронирование
    {
        public int Id { get; set; }
        public required DateTime StartDate { get; set; } ///дата и время въезда
        public DateTime EndDate { get; set; } ///дата и время выезда
        public int SpotId { get; set; }
        public ParkingSpot ReservedSpot { get; set; } ///информация о парковочном месте
    }
}
