using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Phone {get; set;}
        public required string Email { get; set; }
    }
}
