using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ATAS.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected JObject userData;

        [SetUp]
        public void SetUp()
        {
            // Инициализация драйвера Chrome
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Загрузка данных из файла userData.json
            LoadUserData();

            // Увеличение окна браузера для корректного отображения элементов
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            // Закрытие всех браузерных окон и завершение сессии WebDriver
            if (driver != null)
            {
                driver.Quit();
            }
        }

        // Метод загрузки данных пользователя из файла userData.json
        private void LoadUserData()
        {
            // Указываем путь до файла userData.json
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "userData.json");

            // Проверяем наличие файла по указанному пути
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                userData = JObject.Parse(json);
            }
            else
            {
                throw new FileNotFoundException($"Не найден файл userData.json по пути: {path}");
            }
        }


        // Метод перехода по URL
        protected void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        // Метод для ожидания и клика по элементу
        protected void ClickElement(By selector)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(selector));
            element.Click();
        }

        // Метод для ввода текста в поле
        protected void EnterText(By selector, string text)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(selector));
            element.Clear();
            element.SendKeys(text);
        }

        // Метод для проверки отображения элемента
        protected void AssertElementIsVisible(By selector)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(selector));
            Assert.IsTrue(element.Displayed, $"Элемент {selector} не отображается на странице.");
        }
    }
}
