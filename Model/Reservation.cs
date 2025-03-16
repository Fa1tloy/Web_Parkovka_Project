namespace Web_Parkovka_Project.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public int VehicleId { get; set; }
        public Vehicle ReservedVehicle { get; set; }
        public int SpotId { get; set; }
        public ParkingSpot ReservedSpot { get; set; }
    }
}
