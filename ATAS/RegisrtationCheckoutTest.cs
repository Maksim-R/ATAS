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

        }
    }
}
