using ATAS.Test;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using static FormFillTest;

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
        nameInput.SendKeys(UserRu.Name);

        // Ввод Email
        IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-form__email input[type=text]")));
        emailInput.SendKeys(UserRu.EmailPostfix); // Используем текущий EmailPostfix

        // Ввод индекса телефонного кода страны
        IWebElement countryCodeSelect = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".registration-form__country-code")));
        countryCodeSelect.Click();

        // Ввод номера телефона
        IWebElement phoneInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-form__item-phone input[type=text]")));
        phoneInput.SendKeys(UserRu.Phone);

        // Клик на чекбокс Агриментов
        IWebElement checkbox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-form__agreement-checkbox--main .n-checkbox-box-wrapper")));
        checkbox.Click();

        // Клик на кнопке продолжить
        IWebElement continueButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".registration-form__continue")));
        continueButton.Click();

        // Ожидание изменения URL на ожидаемый
        wait.Until(driver => driver.Url.Contains("https://my.trade-with.me/download#wizard"));

        // Дополнительно можно проверять, что на странице действительно находится элемент, который подтверждает, что переход состоялся
        IWebElement wizardElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".registration-wizard"))); // Пример элемента, который появляется на странице после перехода
        Assert.IsTrue(wizardElement.Displayed, "Страница не загружена корректно.");
    }

    [TearDown]
    public void TearDown()
    {
        // Закрытие всех браузерных окон и завершение сессии WebDriver
        driver.Quit();
    }

    // Заглушка для данных пользователя
}

[TestFixture]
public class Authorization // Тест на авторизацию после регистрации
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
    public void AuthorizationAfterRegistration()
    {
        // Ожидание и клик по кнопке Авторизации
        IWebElement authorizationButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".header__authorization-button")));
        authorizationButton.Click();

        // Ввод логина (используем старый email из EmailPostfixOld)
        IWebElement loginInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".n-form-item-blank input[type=text]")));
        loginInput.SendKeys(UserRu.EmailPostfixOld); // Используем старый email (до регистрации)

        // Ввод пароля
        IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".authorization-form__password .n-input__input-el")));
        passwordInput.SendKeys(UserRu.Password);

        // Клик на кнопке входа
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".authorization-form__submit")));
        loginButton.Click();

        // Ожидание изменения URL на ожидаемый
        wait.Until(driver => driver.Url.Contains("https://my.trade-with.me/tariffs"));

        // Дополнительно можно проверять, что на странице действительно находится элемент, который подтверждает, что переход состоялся
        IWebElement wizardElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".header__user-name"))); // Пример элемента, который появляется на странице после перехода
        Assert.IsTrue(wizardElement.Displayed, "Страница не загружена корректно.");
    }

    [TearDown]
    public void TearDown()
    {
        // Закрытие всех браузерных окон и завершение сессии WebDriver
        driver.Quit();
    }
}
