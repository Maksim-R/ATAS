using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

[TestFixture]
class FormFillTest
{
    private IWebDriver driver;
    private WebDriverWait wait;

    [SetUp]
    public void SetUp()
    {
        // Инициализация драйвера для Chrome
        driver = new ChromeDriver();
        // Инициализация явного ожидания с таймаутом 5 секунд
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        // Открытие страницы
        driver.Navigate().GoToUrl("https://my.trade-with.me/cart?id=26&lang=de");

        // Увеличиваем окно браузера, чтобы избежать проблем с видимостью элементов
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void FillForm()
    {
        // Ожидание видимости всех необходимых полей формы
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-contacts__form-email")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-contacts__form-number")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-individual__name")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-individual__surname")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-individual__birth-date")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-address__form-city")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-address__form-zip")));
        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cart-address__form-address")));

        // Заполнение всех полей формы
        FillFormField(0, "BF2024@atas.net");  // Email
        FillFormField(1, "9511234567");       // Phone number (номер телефона)
        FillFormField(2, "TestName");         // First name (имя)
        FillFormField(3, "TestSurname");      // Last name (фамилия)
        FillFormField(4, "11.11.1999");       // Date of birth (дата рождения)
        FillFormField(5, "TestCity");         // City (город)
        FillFormField(6, "123456");           // Postal code (индекс)
        FillFormField(7, "TestAddress");      // Address (адрес)
    }

    /// <summary>
    /// Метод для поиска и заполнения полей ввода на основе их индекса на форме.
    /// Индексы основаны на порядке полей в HTML-структуре формы.
    /// </summary>
    /// <param name="index">Индекс поля (начиная с 0 для первого поля)</param>
    /// <param name="value">Значение, которое нужно ввести в поле</param>
    private void FillFormField(int index, string value)
    {
        try
        {
            // Поиск всех полей формы
            var fields = driver.FindElements(By.CssSelector(".n-input__input-el"));

            // Проверка, что найдено достаточно полей
            if (fields.Count <= index)
            {
                throw new Exception($"Field with index {index} not found.");
            }

            // Ожидание, что поле станет кликабельным
            IWebElement field = fields[index];
            wait.Until(ExpectedConditions.ElementToBeClickable(field));

            // Очистка поля (если нужно) и ввод значения
            field.Clear();  // Очищаем поле ввода перед вводом текста
            field.SendKeys(value);  // Вводим значение в поле
        }
        catch (NoSuchElementException)
        {
            throw new Exception($"Field with index {index} not found.");
        }
        catch (WebDriverTimeoutException)
        {
            throw new Exception($"Field with index {index} was not clickable in time.");
        }
    }

    [TearDown]
    public void TearDown()
    {
        // Оставляем браузер открытым для ручного тестирования
        Console.WriteLine("Тест завершен. Браузер оставлен открытым для ручного тестирования.");
        // Не вызываем driver.Quit(), чтобы браузер не закрылся автоматически
    }
}
