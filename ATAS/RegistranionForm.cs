using ATAS;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

[TestFixture]
public class FormFillTest // Тест на заполнение формы
{
    private IWebDriver driver;
    private WebDriverWait wait;

    [SetUp]
    public void SetUp()
    {
        // Инициализация драйвера Chrome
        driver = new ChromeDriver();

        // Установка времени ожидания для элементов
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        // Переход по URL, указанному в классе Url
        driver.Navigate().GoToUrl(BaseUrl.Tariff.Tariffs);

        // Увеличение окна браузера для корректного отображения элементов
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void RegistrationForm()
    {
        // Проверка URL
        //Assert.IsTrue(driver.Url.Contains("/tariffs"));

        // Ожидание и клик по кнопке Авторизации/Регистрации
        IWebElement authorizationButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".header__authorization-button")));
        authorizationButton.Click();

        // Ожидание и клик кнопки регистрация
        IWebElement signUpButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[data-name=\"signUp\"]")));
        signUpButton.Click();

        // Ввод имени
        IWebElement nameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-form__name input[type=text]")));
        nameInput.SendKeys(User.Name);

        //// Клик на чекбокс Агриментов
        //IWebElement checkbox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-form__agreement-checkbox--main")));
        //checkbox.Click();

        // Ввод Email
        IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-form__email input[type=text]")));
        emailInput.SendKeys(User.EmailPostfix);

        // Ввод индекса телефонного кода страны
        IWebElement countryCodeSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".registration-form__country-code")));
        countryCodeSelect.Click();

        // Ввод номера телефона
        IWebElement phoneInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-form__item-phone input[type=text]")));
        phoneInput.SendKeys(User.Phone);

        // Ожидание и получение списка чекбоксов
        IList<IWebElement> checkboxes = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".registration-form__agreement-checkbox > .n-checkbox-box-wrapper")));

        // Проверка, что список не пуст и содержит хотя бы два элемента
        if (checkboxes.Count >= 2)
        {
            // Выбор второго чекбокса
            IWebElement secondCheckbox = checkboxes[1]; // Использование индекса 1 для доступа к второму элементу
            secondCheckbox.Click();
        }
        else
        {
            // Обработка ситуации, когда нет второго чекбокса
            Console.WriteLine("Не найдено два чекбокса по указанному селектору.");
        }

        // Клик на кнопке продолжить
        IWebElement continueButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".registration-form__continue")));
        continueButton.Click();
    }

    [TearDown]
    public void TearDown()
    {
        // Nothing to do here, browser should not close
    }

    // Заглушка для данных пользователя
    public static class User
    {
        public static string EmailPostfix => "123@example.com";
        public static string IndexPhone => "+7";
        public static string Phone => "9511234567";
        public static string Name => "AutotestName";
    }
}