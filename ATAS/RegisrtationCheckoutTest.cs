using NUnit.Framework;
using OpenQA.Selenium;
using ATAS.Tests;
using SeleniumExtras.WaitHelpers;

namespace ATAS.Tests
{
    public class RegisrtationCheckoutTest : BaseTest
    {
        public void RegistrationCheckoutGlobal()
        {
            // Переход на страницу тарифов
            GoToUrl(BaseUrl.Tariff.Tariffs);

            // Явное ожидание загрузки страницы тарифов
            wait.Until(driver => driver.Url.Contains("https://my.trade-with.me/tariffs"));

            // Проверка, что текущий URL соответствует странице тарифов
            Assert.IsTrue(driver.Url.Contains("https://my.trade-with.me/tariffs"), "Открыта неверная страница для теста авторизации.");

        }
    }
}
