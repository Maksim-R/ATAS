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
            

        }
    }
}
