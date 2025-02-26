using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class ParkingPlaces
    {
        public int Id { get; set; }
        public required string Number { get; set; }
        public required bool Occupancy { get; set; }
        public required string Size { get; set; }
    }
}
