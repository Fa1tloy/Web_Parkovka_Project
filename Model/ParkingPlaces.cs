using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class ParkingPlaces
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется номер парковочного места.")]
        [StringLength(5, ErrorMessage = "Номер парковочного места не может быть длиннее 5 символов.")]
        public required string Number { get; set; }

        [Required(ErrorMessage = "Требуется информация, занято или свободно парковочное место.")]
        [StringLength(8, ErrorMessage = "Информация о статусе парковочного места не может быть длиннее 8 символов.")]
        public required bool Occupancy { get; set; }

        [Required(ErrorMessage = "Требуется указать размер парковочного места.")]
        [StringLength(10, ErrorMessage = "Размер парковочного места не может быть длиннее 10 символов.")]
        public required string Size { get; set; }
    }
}
