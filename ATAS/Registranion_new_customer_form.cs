// Импорт необходимых namespace для работы с Selenium WebDriver, ChromeDriver, поддержкой UI и NUnit
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System;

// Определение namespace для тестов регистрации на странице Atas
namespace Registranion_new_customer_form
{
    // Статический класс для хранения локаторов элементов на странице
    public static class Locators
    {
        // Локатор кнопки авторизации
        public static readonly By SignInAuthorizationButton = By.CssSelector("button.header__authorization-button");
        // Локатор кнопки регистрации
        public static readonly By SignInRegistrationButton = By.CssSelector("div[data-name='signUp'].n-tabs-tab");
        // Локатор поля ввода имени пользователя
        public static readonly By UserNameInputButton = By.CssSelector("div.n-input.registration-form__name");
        // Локатор поля ввода электронной почты пользователя
        public static readonly By UserEmailInputButton = By.CssSelector("div.n-input.registration-form__email");
        // Локатор поля ввода телефона пользователя
        public static readonly By UserPhoneInputButton = By.CssSelector("div.n-form-item.registration-form__item-phone");
        // Локатор чекбокса согласия
        public static readonly By CheckBoxAgreement = By.CssSelector("span.n-checkbox__label#0f657db2");
        // Локатор кнопки продолжения
        public static readonly By ContinueButton = By.CssSelector("button.registration-form__continue");
    }

    // Статический класс для хранения данных пользователя
    public static class UserData
    {
        // Константа для имени пользователя
        public const string Name = "TestSelenium";
        // Константа для электронной почты пользователя
        public const string Email = "TestSelenium@atas.net";
        // Константа для телефона пользователя
        public const string Phone = "9511234567";
    }

    // Класс для тестов
    public class Tests
    {
        // Переменная для хранения экземпляра WebDriver
        private IWebDriver driver;
        // Переменная для хранения экземпляра WebDriverWait
        private WebDriverWait wait;

        // Метод Setup, выполняемый перед каждым тестом
        [SetUp]
        public void Setup()
        {
            // Создание экземпляра ChromeOptions для настройки браузера
            var options = new ChromeOptions();
            // Добавление аргумента для запуска браузера в headless режиме
            options.AddArgument("--headless");
            // Инициализация экземпляра ChromeDriver с заданными опциями
            driver = new ChromeDriver(options);
            // Максимальное развертывание окна браузера
            driver.Manage().Window.Maximize();
            // Навигация к указанной URL
            driver.Navigate().GoToUrl("https://my.trade-with.me/tariffs");
            // Создание экземпляра WebDriverWait с таймаутом 10 секунд
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Метод теста регистрации
        [Test]
        public void Test1()
        {
            // Ожидание кликабельности кнопки авторизации и клик по ней
            wait.Until(ExpectedConditions.ElementToBeClickable(Locators.SignInAuthorizationButton)).Click();
            // Ожидание кликабельности кнопки регистрации и клик по ней
            wait.Until(ExpectedConditions.ElementToBeClickable(Locators.SignInRegistrationButton)).Click();

            // Ожидание видимости поля ввода имени пользователя и ввод имени
            var userName = wait.Until(ExpectedConditions.ElementIsVisible(Locators.UserNameInputButton));
            userName.SendKeys(UserData.Name);

            // Ожидание видимости поля ввода электронной почты пользователя и ввод электронной почты
            var userEmail = wait.Until(ExpectedConditions.ElementIsVisible(Locators.UserEmailInputButton));
            userEmail.SendKeys(UserData.Email);

            // Ожидание видимости поля ввода телефона пользователя и ввод телефона
            var userPhone = wait.Until(ExpectedConditions.ElementIsVisible(Locators.UserPhoneInputButton));
            userPhone.SendKeys(UserData.Phone);

            // Ожидание видимости чекбокса согласия и клик по нему
            var checkBoxAgreement = wait.Until(ExpectedConditions.ElementIsVisible(Locators.CheckBoxAgreement));
            checkBoxAgreement.Click();

            // Ожидание кликабельности кнопки продолжения и клик по ней
            var continueButton = wait.Until(ExpectedConditions.ElementToBeClickable(Locators.ContinueButton));
            continueButton.Click();

            // Дополнительная проверка на успешную регистрацию (может зависеть от вашего приложения)
            // Например, можно ожидать появления какого-либо элемента, который появляется только после успешной регистрации
        }

        // Метод TearDown, выполняемый после каждого теста
        [TearDown]
        public void TearDown()
        {
            // Проверка наличия экземпляра WebDriver и его закрытие
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}