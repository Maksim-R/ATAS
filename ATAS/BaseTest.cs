using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using ATAS.Test;

namespace ATAS.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected JObject? userData;
        protected JObject? paymentProfiles;


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

            // Загрузка данных из файла paymentProfilesLv.json
            //LoadPaymentProfile();

            // Увеличение окна браузера для корректного отображения элементов
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Очистка ресурсов после выполнения тестов: закрытие браузера и завершение сессии WebDriver.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Закрываем браузер и завершаем сессию WebDriver
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
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
        /// Получает значение из данных пользователя по указанному ключу.
        /// </summary>
        /// <param name="key">Ключ для поиска данных пользователя в объекте <c>userData</c>.</param>
        /// <returns>Возвращает строку, которая является значением для указанного ключа.</returns>
        /// <exception cref="InvalidOperationException">
        /// Исключение возникает, если <c>userData</c> равно <c>null</c> или если в данных пользователя нет значения для указанного ключа.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Исключение возникает, если <c>key</c> является <c>null</c> или пустой строкой.
        /// </exception>
        protected string GetUserData(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть null или пустым.");
            }

            // Проверка на null и наличие ключа
            if (userData == null || userData[key] == null)
            {
                throw new InvalidOperationException($"Отсутствуют данные для ключа: {key}");
            }

            return userData[key]?.ToString() ?? throw new InvalidOperationException($"Не удалось получить значение для ключа: {key}");
        }


        /// <summary>
        /// Загружает профиль платежных данных из файла <c>paymentProfilesLv.json</c>,
        /// расположенного в папке <c>PaymentProfiles</c> внутри директории <c>TestData</c>.
        /// </summary>
        /// <remarks>
        /// Метод считывает содержимое файла <c>paymentProfilesLv.json</c> и парсит его в объект <c>JObject</c>.
        /// </remarks>
        /// <exception cref="FileNotFoundException">
        /// Возникает, если файл <c>paymentProfilesLv.json</c> не найден по указанному пути.
        /// </exception>
        protected void LoadPaymentProfile()
        {
            // Путь к файлу относительно базовой директории проекта
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "PaymentProfiles", "paymentProfilesLv.json");

            if (File.Exists(path))
            {
                paymentProfiles = JObject.Parse(File.ReadAllText(path));
            }
            else
            {
                throw new FileNotFoundException($"Не найден файл paymentProfilesLv.json по пути: {path}");
            }
        }

        /// <summary>
        /// Получает профиль платежных данных по ключу из объекта <c>paymentProfiles</c>.
        /// </summary>
        /// <param name="key">Ключ для поиска данных в профиле платежей.</param>
        /// <returns>Возвращает строку, которая является значением для указанного ключа в профиле платежей.</returns>
        /// <exception cref="InvalidOperationException">
        /// Исключение возникает, если <c>paymentProfiles</c> равно <c>null</c> или если в профиле платежей нет значения для указанного ключа.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Исключение возникает, если <c>key</c> является <c>null</c> или пустой строкой.
        /// </exception>
        protected string GetPaymentProfileData(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Ключ не может быть null или пустым.");
            }

            // Проверка на null и наличие ключа
            if (paymentProfiles == null || paymentProfiles[key] == null)
            {
                throw new InvalidOperationException($"Отсутствуют данные для ключа: {key} в профиле платежей.");
            }

            return paymentProfiles[key]?.ToString() ?? throw new InvalidOperationException($"Не удалось получить значение для ключа: {key} в профиле платежей.");
        }

        /// <summary>
        /// Переходит по указанному URL.
        /// </summary>
        /// <param name="url">URL для перехода (значение из BaseUrl).</param>
        protected void GoToUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("URL не может быть пустым.", nameof(url));
            }

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
            element = wait.Until(ExpectedConditions.ElementToBeClickable(selector));
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

        /// <summary>
        /// Генерирует случайный адрес электронной почты в домене <c>test@atas.net</c>.
        /// </summary>
        /// <returns>Случайный адрес электронной почты в формате <c>abc-test@atas.net</c>, где "abc" — случайная строка длиной 3 символа.</returns>
        public static string GenerateRandomEmail()
        {
            // Генерация случайной строки перед "test@atas.net"
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 3); // генерирует строку длиной 3 символа
            return randomPart + "test@atas.net";
        }

        /// <summary>
        /// Выбирает значение в нестандартном выпадающем списке на основе заданных селекторов.
        /// </summary>
        /// <param name="dropdownSelector">
        /// Селектор выпадающего списка, по которому будет выполнен клик для открытия.
        /// </param>
        /// <param name="inputFieldSelector">
        /// Селектор текстового поля, связанного с выпадающим списком, для ввода значения.
        /// </param>
        /// <param name="optionText">
        /// Текст значения, который нужно выбрать в выпадающем списке.
        /// </param>
        /// <remarks>
        /// Метод обрабатывает случаи, когда элемент текстового поля отключен или доступен только для чтения
        /// (атрибуты <c>disabled</c> или <c>readonly</c>). В таких случаях выполнение метода будет пропущено,
        /// а управление перейдет к следующему полю.
        /// </remarks>
        /// <exception cref="WebDriverTimeoutException">
        /// Выбрасывается, если указанные элементы не появляются в течение времени ожидания.
        /// </exception>
        /// <example>
        /// Пример использования метода:
        /// <code>
        /// SelectDropdown(
        ///     By.CssSelector(".cart-address__form-country"),
        ///     By.CssSelector(".cart-address__form-country .n-base-selection-input"),
        ///     "Nepal"
        /// );
        /// </code>
        /// </example>
        protected void SelectDropdown(By dropdownSelector, By inputFieldSelector, string optionText)
        {
            // Ожидаем, что элемент выпадающего списка доступен для клика
            IWebElement dropdownElement = wait.Until(ExpectedConditions.ElementToBeClickable(dropdownSelector));
            dropdownElement.Click(); // Открываем выпадающий список

            // Проверяем наличие поля для ввода
            IWebElement inputField = wait.Until(ExpectedConditions.ElementExists(inputFieldSelector));

            // Если поле отключено, пропускаем заполнение
            if (!inputField.Enabled || inputField.GetAttribute("readonly") == "true")
            {
                Console.WriteLine($"Поле {inputFieldSelector} отключено. Пропускаем заполнение.");
                return;
            }

            // Вводим текст и подтверждаем выбор клавишей Enter
            inputField.SendKeys(optionText);
            inputField.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Подтверждает OTP-код, введя его в соответствующее поле.
        /// </summary>
        protected void ConfirmOTP()
        {
            // Предполагаем, что код OTP был отправлен и его нужно ввести в поле
            // Найдите поле для ввода OTP, например:
            IWebElement otpField = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".otp-input")));

            // Введите OTP, например "123456" (можно заменить на динамическое получение кода)
            otpField.SendKeys("123456");

            // Если есть кнопка подтверждения OTP, кликаем по ней
            IWebElement confirmButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".otp-confirm-button")));
            confirmButton.Click();
        }

    }
}
