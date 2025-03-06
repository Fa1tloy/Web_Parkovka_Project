using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется Ф.И.О владельца автомобиля.")]
        [StringLength(75, ErrorMessage = "Ф.И.О не может быть длиннее 75 символов.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Требуется номер телефона владельца автомобиля.")]
        [StringLength(12, ErrorMessage = "номер телефона не может быть длиннее 12 символов.")]
        public required string Phone {get; set;}

        [Required(ErrorMessage = "Требуется электронная почта владельца автомобиля.")]
        [StringLength(70, ErrorMessage = "номер не может быть длиннее 70 символов.")]
        public required string Email { get; set; }
    }
}
