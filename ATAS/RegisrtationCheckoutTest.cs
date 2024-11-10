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

        }
    }
}
