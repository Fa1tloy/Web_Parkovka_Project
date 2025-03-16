namespace Web_Parkovka_Project.Model
{
    public class Reservation ///бронирование
    {
        public int Id { get; set; }
        public required DateTime StartDate { get; set; } ///дата и время въезда
        public required DateTime EndDate { get; set; } ///дата и время выезда
        public int VehicleId { get; set; }
        public Vehicle ReservedVehicle { get; set; } ///информация о транспортном средстве, каждая бронь связана с конкретным транспортным средством
        public int SpotId { get; set; }
        public ParkingSpot ReservedSpot { get; set; } ///информация о парковочном месте
    }
}
