using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class Cars
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется номер автомобиля.")]
        [StringLength(10, ErrorMessage = "номер не может быть длиннее 10 символов.")]
        public required string Number { get; set; }

        [Required(ErrorMessage = "Требуется название модели автомобиля.")]
        [StringLength(70, ErrorMessage = "Модель не может быть длиннее 70 символов.")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Требуется ввести цвет автомобиля.")]
        [StringLength(50, ErrorMessage = "Цвет не может быть длиннее 50 символов.")]
        public required string Colour { get; set; }

        [Required(ErrorMessage = "Требуется ID владельца.")]
        [StringLength(6, ErrorMessage = "ID не может быть длиннее 6 символов.")]
        public required int OwnerId { get; set; }

        [Required(ErrorMessage = "Требуется Ф.И.О владельца.")]
        [StringLength(80, ErrorMessage = "Ф.И.О не может быть длиннее 80 символов.")]
        public required Owner Owner { get; set; }
    }
}
