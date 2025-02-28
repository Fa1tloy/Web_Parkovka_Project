using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class ParkingRecords
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public required Cars Car { get; set; }
        public int ParkingPlacesId { get; set; }
        public required ParkingPlaces ParkingPlace { get; set; }
        public DateTime Entrance { get; set; } = DateTime.Now;
        public DateTime Exit { get; set; }
        public int Payment { get; set; }
    }
}

