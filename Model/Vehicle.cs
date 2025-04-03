using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class Vehicle ///транспортное средство
    {
        public int Id { get; set; }

        [StringLength(100)]
        public required string Make { get; set; } ///марка транспортного средства

        [StringLength(100)]
        public required string Model { get; set; } ///модель транспортного средства

        [RegularExpression(@"^[A-Z]\d{5}$")]
        public required string LicensePlate { get; set; } ///номерной знак транспортного средства
        public int OwnerId { get; set; }
        public User Owner { get; set; } ///информация о владельце транспортного средства
    }
}
