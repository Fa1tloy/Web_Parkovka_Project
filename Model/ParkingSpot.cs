namespace Web_Parkovka_Project.Model
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public required int Number { get; set; } ///номер парковочного места
        public required bool IsOccupied { get; set; } ///занятость
        public int? VehicleId { get; set; }
        public Vehicle OccupiedBy { get; set; } ///каждое парковочное место связано с конкретным транспортным средством, которое его занимает
    }
}
