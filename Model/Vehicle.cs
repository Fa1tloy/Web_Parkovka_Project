namespace Web_Parkovka_Project.Model
{
    public class Vehicle ///транспортное средство
    {
        public int Id { get; set; }
        public required string Make { get; set; } ///марка транспортного средства
        public required string Model { get; set; } ///модель транспортного средства
        public required string LicensePlate { get; set; } ///номерной знак транспортного средства
        public int OwnerId { get; set; }
        public User Owner { get; set; } ///информация о владельце транспортного средства
    }
}
