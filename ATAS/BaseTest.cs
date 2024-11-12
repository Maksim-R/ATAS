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

        /// <summary>
        /// Настройка перед выполнением тестов: инициализация WebDriver, загрузка данных пользователя и настройка окна браузера.
        /// </summary>
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

        /// <summary>
        /// Очистка ресурсов после выполнения тестов: закрытие браузера и завершение сессии WebDriver.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        /// <summary>
        /// Загружает данные пользователя из файла userData.json, расположенного в папке TestData.
        /// </summary>
        /// <exception cref="FileNotFoundException">Исключение, если файл userData.json не найден по указанному пути.</exception>
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

        /// <summary>
        /// Переходит по указанному URL.
        /// </summary>
        /// <param name="url">URL для перехода.</param>
        protected void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Ожидает, пока элемент станет кликабельным, и выполняет клик по нему.
        /// </summary>
        /// <param name="selector">Селектор элемента для клика.</param>
        protected void ClickElement(By selector)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(selector));
            element.Click();
        }

        /// <summary>
        /// Находит поле по селектору, очищает его и вводит указанный текст.
        /// </summary>
        /// <param name="selector">Селектор поля для ввода текста.</param>
        /// <param name="text">Текст для ввода в поле.</param>
        protected void EnterText(By selector, string text)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(selector));
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Проверяет, что элемент с указанным селектором отображается на странице.
        /// </summary>
        /// <param name="selector">Селектор элемента для проверки.</param>
        /// <exception cref="AssertionException">Исключение, если элемент не отображается.</exception>
        protected void AssertElementIsVisible(By selector)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(selector));
            Assert.IsTrue(element.Displayed, $"Элемент {selector} не отображается на странице.");
        }
    }
}
