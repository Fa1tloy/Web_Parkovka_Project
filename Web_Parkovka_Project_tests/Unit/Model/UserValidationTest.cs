using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project_tests.Unit.Model
{
    public class UserValidationTest
    {
        [Fact]
        public void User_WithValidData_ShouldBeValid()
        {
            var user = new User
            {
                Name = "Иван",
                Surname = " Каштанов",
                Patronymic = "Каштанович",
                Email = "baranovdaniil534@gmail.com",
                PhoneNumber= "+79001234567",
              
            };

            var context = new ValidationContext(user);
            var result = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(user, context, result, true);

            Assert.True(isValid);
        }

        [Fact]
        public void User_WithInvalidEmail_ShouldBeInvalid()
        {
            var user = new User
            {
                Name = "Иван",
                Surname = "Иванов",
                Patronymic = "Иванович",
                Email = "invalid_email",
                PhoneNumber = "+89622345766",
            };

            var context = new ValidationContext(user);
            var result = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(user, context, result, true);

            Assert.False(isValid);
            Assert.Contains(result, r => r.ErrorMessage == "Введите корректный Email");
        }
    }
}
