namespace Web_Parkovka_Project.Model
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public required int Number { get; set; }
        public required bool IsOccupied { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle OccupiedBy { get; set; }
    }
}
