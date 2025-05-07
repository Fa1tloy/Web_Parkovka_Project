using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Parkovka_Project_tests.Functional
{
    public class ParkingTest
    {
        private IWebDriver driver;

        public ParkingTest()
        {
            driver = new ChromeDriver();
        }

        [Fact]
        public void CanAddBook()
        {
            // Arrange
            driver.Navigate().GoToUrl("http://localhost:5163/Books");

            // Act
            driver.FindElement(By.Id("Title")).SendKeys("C# in Depth");
            driver.FindElement(By.Id("Author")).SendKeys("Jon Skeet");
            driver.FindElement(By.Id("Year")).SendKeys("2020");
            driver.FindElement(By.Id("SubmitButton")).Click();

            // Assert
            var confirmationMessage = driver.FindElement(By.Id("ConfirmationMessage")).Text;
            Assert.Equal("Книга успешно добавлена", confirmationMessage);

            var booksList = driver.FindElement(By.Id("BooksList")).Text;
            Assert.Contains("C# in Depth", booksList);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
