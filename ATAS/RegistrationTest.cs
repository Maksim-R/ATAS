using NUnit.Framework;
using OpenQA.Selenium;
using ATAS.Tests;
using SeleniumExtras.WaitHelpers;
using ATAS.Test;

namespace ATAS.Tests
{
    [TestFixture]
    public class RegistrationTest : BaseTest
    {
        [Test]
        public void RegistrationFormTest()
        {
            // Переход на страницу тарифов
            GoToUrl(BaseUrl.Page.Shop);

            // Явное ожидание загрузки страницы тарифов
            wait.Until(driver => driver.Url.Contains("https://my.trade-with.me/tariffs"));

            // Проверка, что текущий URL соответствует странице тарифов
            Assert.IsTrue(driver.Url.Contains("https://my.trade-with.me/tariffs"), "Открыта неверная страница для теста авторизации.");

            // Ожидание и клик по кнопке Авторизации/Регистрации
            ClickElement(By.CssSelector(".header__authorization-button"));

            // Проверка, что кнопка регистрации видна
            AssertElementIsVisible(By.CssSelector("div[data-name=\"signUp\"]"));
            ClickElement(By.CssSelector("div[data-name=\"signUp\"]"));

            // Проверка заголовка формы регистрации
            IWebElement registrationTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-name=\"signUp\"] .n-tabs-tab__label")));
            Assert.AreEqual("Регистрация", registrationTitle.Text, "Заголовок формы регистрации не совпадает.");

            // Проверка наличия поля ввода имени
            AssertElementIsVisible(By.CssSelector(".registration-form__name input[type=text]"));

            // Ввод имени
            EnterText(By.CssSelector(".registration-form__name input[type=text]"), userData["name"].ToString());

            // Проверка наличия поля ввода email
            AssertElementIsVisible(By.CssSelector(".registration-form__email input[type=text]"));
            EnterText(By.CssSelector(".registration-form__email input[type=text]"), userData["name"].ToString());

            // Проверка наличия поля ввода номера телефона
            AssertElementIsVisible(By.CssSelector(".registration-form__item-phone input[type=text]"));
            EnterText(By.CssSelector(".registration-form__item-phone input[type=text]"), UserRu.Phone);

            // Принятие условий соглашения
            AssertElementIsVisible(By.CssSelector(".registration-form__agreement-checkbox--main .n-checkbox-box-wrapper"));
            ClickElement(By.CssSelector(".registration-form__agreement-checkbox--main .n-checkbox-box-wrapper"));

            // Проверка наличия кнопки продолжить
            AssertElementIsVisible(By.CssSelector(".registration-form__continue"));
            ClickElement(By.CssSelector(".registration-form__continue"));

            // Проверка, что URL изменился на страницу загрузки
            wait.Until(driver => driver.Url.Contains(BaseUrl.Page.Wizard));
            Assert.IsTrue(driver.Url.Contains(BaseUrl.Page.Wizard), "Пользователь не перенаправлен на страницу загрузки.");

            // Проверка наличия элемента на странице загрузки (например, блока с регистрационным мастером)
            AssertElementIsVisible(By.CssSelector(".registration-wizard"));
        }        

    }
}
