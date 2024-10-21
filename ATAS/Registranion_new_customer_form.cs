// ������ ����������� namespace ��� ������ � Selenium WebDriver, ChromeDriver, ���������� UI � NUnit
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System;

// ����������� namespace ��� ������ ����������� �� �������� Atas
namespace Registranion_new_customer_form
{
    // ����������� ����� ��� �������� ��������� ��������� �� ��������
    public static class Locators
    {
        // ������� ������ �����������
        public static readonly By SignInAuthorizationButton = By.CssSelector("button.header__authorization-button");
        // ������� ������ �����������
        public static readonly By SignInRegistrationButton = By.CssSelector("div[data-name='signUp'].n-tabs-tab");
        // ������� ���� ����� ����� ������������
        public static readonly By UserNameInputButton = By.CssSelector("div.n-input.registration-form__name");
        // ������� ���� ����� ����������� ����� ������������
        public static readonly By UserEmailInputButton = By.CssSelector("div.n-input.registration-form__email");
        // ������� ���� ����� �������� ������������
        public static readonly By UserPhoneInputButton = By.CssSelector("div.n-form-item.registration-form__item-phone");
        // ������� �������� ��������
        public static readonly By CheckBoxAgreement = By.CssSelector("span.n-checkbox__label#0f657db2");
        // ������� ������ �����������
        public static readonly By ContinueButton = By.CssSelector("button.registration-form__continue");
    }

    // ����������� ����� ��� �������� ������ ������������
    public static class UserData
    {
        // ��������� ��� ����� ������������
        public const string Name = "TestSelenium";
        // ��������� ��� ����������� ����� ������������
        public const string Email = "TestSelenium@atas.net";
        // ��������� ��� �������� ������������
        public const string Phone = "9511234567";
    }

    // ����� ��� ������
    public class Tests
    {
        // ���������� ��� �������� ���������� WebDriver
        private IWebDriver driver;
        // ���������� ��� �������� ���������� WebDriverWait
        private WebDriverWait wait;

        // ����� Setup, ����������� ����� ������ ������
        [SetUp]
        public void Setup()
        {
            // �������� ���������� ChromeOptions ��� ��������� ��������
            var options = new ChromeOptions();
            // ���������� ��������� ��� ������� �������� � headless ������
            options.AddArgument("--headless");
            // ������������� ���������� ChromeDriver � ��������� �������
            driver = new ChromeDriver(options);
            // ������������ ������������� ���� ��������
            driver.Manage().Window.Maximize();
            // ��������� � ��������� URL
            driver.Navigate().GoToUrl("https://my.trade-with.me/tariffs");
            // �������� ���������� WebDriverWait � ��������� 10 ������
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // ����� ����� �����������
        [Test]
        public void Test1()
        {
            // �������� �������������� ������ ����������� � ���� �� ���
            wait.Until(ExpectedConditions.ElementToBeClickable(Locators.SignInAuthorizationButton)).Click();
            // �������� �������������� ������ ����������� � ���� �� ���
            wait.Until(ExpectedConditions.ElementToBeClickable(Locators.SignInRegistrationButton)).Click();

            // �������� ��������� ���� ����� ����� ������������ � ���� �����
            var userName = wait.Until(ExpectedConditions.ElementIsVisible(Locators.UserNameInputButton));
            userName.SendKeys(UserData.Name);

            // �������� ��������� ���� ����� ����������� ����� ������������ � ���� ����������� �����
            var userEmail = wait.Until(ExpectedConditions.ElementIsVisible(Locators.UserEmailInputButton));
            userEmail.SendKeys(UserData.Email);

            // �������� ��������� ���� ����� �������� ������������ � ���� ��������
            var userPhone = wait.Until(ExpectedConditions.ElementIsVisible(Locators.UserPhoneInputButton));
            userPhone.SendKeys(UserData.Phone);

            // �������� ��������� �������� �������� � ���� �� ����
            var checkBoxAgreement = wait.Until(ExpectedConditions.ElementIsVisible(Locators.CheckBoxAgreement));
            checkBoxAgreement.Click();

            // �������� �������������� ������ ����������� � ���� �� ���
            var continueButton = wait.Until(ExpectedConditions.ElementToBeClickable(Locators.ContinueButton));
            continueButton.Click();

            // �������������� �������� �� �������� ����������� (����� �������� �� ������ ����������)
            // ��������, ����� ������� ��������� ������-���� ��������, ������� ���������� ������ ����� �������� �����������
        }

        // ����� TearDown, ����������� ����� ������� �����
        [TearDown]
        public void TearDown()
        {
            // �������� ������� ���������� WebDriver � ��� ��������
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}