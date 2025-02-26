using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class Cars
    {
        public int Id { get; set; }
        public required string Number { get; set; }
        public required string Model { get; set; }
        public required string Colour { get; set; }
        public required int OwnerId { get; set; }
        public required Owner Owner { get; set; }
    }
}
