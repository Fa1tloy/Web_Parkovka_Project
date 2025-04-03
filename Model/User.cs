using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class User ///пользователь, он же владелец транспортного средства
    {
        public int Id { get; set; }
        [StringLength(50)]
        public required string Name { get; set; } ///имя пользователя
        [StringLength(50)]
        public required string Surname { get; set; } ///фамилия пользователя
        [StringLength(50)]
        public string Patronymic { get; set; } ///отчество пользователя
        [EmailAddress]
        public string Email { get; set; } ///эл.почта пользователя
        [Phone]
        public string PhoneNumber { get; set; } ///номер телефона пользователя

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); ///что каждый пользователь может владеть несколькими транспортными средствами
    }
}
