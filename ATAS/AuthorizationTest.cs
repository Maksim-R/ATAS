using NUnit.Framework;
using OpenQA.Selenium;
using ATAS.Tests;
using SeleniumExtras.WaitHelpers;
using ATAS.Test;

namespace ATAS.Tests
{
    [TestFixture]
    public class AuthorizationTest : BaseTest
    {
        [Test]
        public void AuthorizationAfterRegistrationTest()
        {
            // Переход на страницу тарифов
            GoToUrl(BaseUrl.Page.Shop);

            // Явное ожидание загрузки страницы тарифов
            wait.Until(driver => driver.Url.Contains("https://my.trade-with.me/tariffs"));

            // Проверка, что текущий URL соответствует странице тарифов
            Assert.IsTrue(driver.Url.Contains("https://my.trade-with.me/tariffs"), "Открыта неверная страница для теста авторизации.");

            // Ожидание и клик по кнопке Авторизации
            ClickElement(By.CssSelector(".header__authorization-button"));

            // Проверка наличия поля ввода email
            AssertElementIsVisible(By.CssSelector(".n-form-item-blank input[type=text]"));
            EnterText(By.CssSelector(".n-form-item-blank input[type=text]"), userData["authorizationEmail"].ToString());

            // Проверка наличия поля ввода пароля
            AssertElementIsVisible(By.CssSelector(".authorization-form__password .n-input__input-el"));
            EnterText(By.CssSelector(".authorization-form__password .n-input__input-el"), userData["authorizationPassword"].ToString());

            // Проверка наличия кнопки Войти
            AssertElementIsVisible(By.CssSelector(".authorization-form__submit"));
            ClickElement(By.CssSelector(".authorization-form__submit"));

            // Проверка изменения URL после успешной авторизации
            wait.Until(driver => driver.Url.Contains("https://my.trade-with.me/tariffs"));
            Assert.IsTrue(driver.Url.Contains("https://my.trade-with.me/tariffs"), "Пользователь не перенаправлен на страницу тарифов после авторизации.");

            // Проверка отображения имени пользователя в шапке страницы
            IWebElement userNameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".header__user-name")));
            Assert.IsTrue(userNameElement.Displayed, "Имя пользователя не отображается в шапке страницы после авторизации.");

            // Проверка корректности имени пользователя (если данные доступны)
            //string expectedUserName = userData["name"].ToString();
            //Assert.AreEqual(expectedUserName, userNameElement.Text, $"Имя пользователя не совпадает. Ожидаемое: {expectedUserName}, фактическое: {userNameElement.Text}");
        }

    }
}
