using NUnit.Framework;
using OpenQA.Selenium;
using ATAS.Tests;
using SeleniumExtras.WaitHelpers;
using ATAS.Test;

namespace ATAS.Tests
{
    public class RegisrtationCheckoutTest : BaseTest
    {
        [Test]
        public void RegistrationCheckoutGlobal()
        {
            // Переход на страницу тарифов
            GoToUrl(BaseUrl.Page.Shop);

            // Клик по ссылке "с бонусным периодом"
            ClickElement(By.CssSelector(".plan__footer-description .link"));

            // Генерируем рандомный email
            string randomEmail = BaseTest.GenerateRandomEmail();

            // Ввод Email
            EnterText(By.CssSelector(".cart-contacts__form-email input[type=text]"), randomEmail);

            // Выбор телефонного кода страны
            EnterText(By.CssSelector(".cart-contacts__form-email input[type=text]"), userData["phoneCode"].ToString());        
                        
            // Ввод номера телефона
            EnterText(By.CssSelector(".cart-contacts__form-number input[type=text]"), userData["phone"].ToString());
            
            // Ввод Имени
            EnterText(By.CssSelector(".cart-individual__name input[type=text]"), userData["name"].ToString());
            
            // Ввод Фамилии
            EnterText(By.CssSelector(".cart-individual__surname input[type=text]"), userData["surname"].ToString());
            
            // Ввод Даты рождения
            EnterText(By.CssSelector(".cart-individual__birth-date input[type=text]"), userData["birthDate"].ToString());
            
            // Ввод страны
            EnterText(By.CssSelector(".cart-individual__birth-date input[type=text]"), userData["birthDate"].ToString());

        }
    }
}
