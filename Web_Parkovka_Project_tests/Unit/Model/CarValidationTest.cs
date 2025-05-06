using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project_tests.Unit.Model
{
    public class CarValidationTest
    {
        [Fact]
        public void Car_WithValidData_ShouldBeValid()
        {
            // Создаем объект книги с валидными значениями.
            var car = new Vehicle
            {
                Make = "АвтоВАЗ",     // Обязательное поле, строка < 100 символов
                Model = "Жигуль",      // Обязательное поле, строка < 100 символов
                LicensePlate = "A12345",
            };

            // Создаем контекст валидации на основе объекта
            var context = new ValidationContext(car);

            // Сюда будут записаны ошибки валидации, если они есть
            var result = new List<ValidationResult>();

            // Проводим валидацию объекта с учетом всех атрибутов [Required], [Range] и т.п.
            var isValid = Validator.TryValidateObject(car, context, result, true);

            // Ожидаем, что валидация прошла успешно (все поля корректны)
            Assert.True(isValid);

            // Также убеждаемся, что список ошибок пуст
            Assert.Empty(result);
        }

        // Тест проверяет, что если указать неправильно номерной знак, то объект будет невалиден.
        [Fact]
        public void Car_WithEmptyTitle_ShouldBeInvalid()
        {
            // Создаем объект транспортного средства с неправильным номерным знаком
            var car = new Vehicle
            {
                Make = "АвтоВАЗ",     // Обязательное поле, строка < 100 символов
                Model = "Ока",      // Обязательное поле, строка < 100 символов
                LicensePlate = "345",             
            };

            var context = new ValidationContext(car);
            var result = new List<ValidationResult>();

            // Выполняем валидацию
            var isValid = Validator.TryValidateObject(car, context, result, true);

            // Ожидаем, что объект не прошел валидацию
            Assert.False(isValid);

            // Проверяем, что ошибка касается конкретно заголовка
            Assert.Contains(result, r => r.ErrorMessage == "Требуется правильной ввод номерного знака.");
        }
    }
}
