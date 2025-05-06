namespace Web_Parkovka_Project.DTOs.User
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName => $"{Surname} {Name} {Patronymic}".Trim();
        public List<VehicleDTO> Vehicles { get; set; } = new List<VehicleDTO>();
    }
}
