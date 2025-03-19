using System.ComponentModel.DataAnnotations;

namespace Web_Parkovka_Project.Model
{
    public class User ///пользователь, он же владелец транспортного средства
    {
        public int Id { get; set; }
        public required string Name { get; set; } ///имя пользователя
        public required string Surname { get; set; } ///фамилия пользователя
        public string Patronymic { get; set; } ///отчество пользователя
        public required string Email { get; set; } ///эл.почта пользователя
        public required string PhoneNumber { get; set; } ///номер телефона пользователя

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); ///что каждый пользователь может владеть несколькими транспортными средствами
    }
}
