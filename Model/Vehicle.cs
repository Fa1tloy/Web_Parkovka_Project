namespace Web_Parkovka_Project.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required string LicensePlate { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<ParkingSpot> ParkedAtSpots { get; set; } = new List<ParkingSpot>();
    }
}
