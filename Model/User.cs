using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string MiddleName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
