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
        public void BuyTest()
        {

            // Переход на страницу тарифов
            GoToUrl(BaseUrl.Page.GlobalStandard.Id5);

            string email = GenerateRandomEmail();

            // Ввод email
            EnterText(By.CssSelector(".cart-contacts__form-email input[type=text]"), email);

            // Ввод кода страны
            // Найти элемент, в котором отображается код (например, +49)
            var phoneCodeElement = driver.FindElement(By.CssSelector(".n-base-selection-label"));

            // Кликнуть по элементу, чтобы открыть выпадающий список или редактируемое поле
            //phoneCodeElement.Click();

            //// Найти элемент с новым кодом (+7) и выбрать его
            //var newCodeElement = driver.FindElement(By.CssSelector("div.n-base-selection-label[title='+7']"));
            //newCodeElement.Click();

            // Или, если это поле ввода, можно просто ввести новый код:
            var inputElement = driver.FindElement(By.CssSelector(".n-base-selection-input"));
            inputElement.Clear();
            inputElement.SendKeys("Russia");

            //// Пример того, чтобы закрыть выпадающий список или сохранить изменения (если это нужно)
            //var saveButton = driver.FindElement(By.CssSelector(".some-save-button"));
            //saveButton.Click(); // Если есть кнопка для подтверждения
            //ClickElement(By.CssSelector(".cart-contacts__form-code"));
            //SelectDropdown(By.CssSelector(".cart-contacts__form-code"), "+7" + Keys.Enter);

            //// Заполнение контактных данных
            //EnterText(By.CssSelector(".cart-contacts__form-number input[type=text]"), GetUserData("phone"));
            //EnterText(By.CssSelector(".cart-individual__name input[type=text]"), GetUserData("surname"));
            //EnterText(By.CssSelector(".cart-individual__surname input[type=text]"), GetUserData("surname"));
            //EnterText(By.CssSelector(".cart-individual__birth-date input[type=text]"), GetUserData("birthDate"));

            //// Заполнение адресных данных
            //EnterText(By.CssSelector(".cart-address__form-country"), GetUserData("country") + Keys.Enter);
            //EnterText(By.CssSelector(".cart-address__form-city input[type=text]"), GetUserData("city"));
            //EnterText(By.CssSelector(".cart-address__form-zip input[type=text]"), GetUserData("zip"));
            //EnterText(By.CssSelector(".cart-address__form-address input[type=text]"), GetUserData("address"));

            //// НДС
            //ClickElement(By.CssSelector(".cart-vat__approval"));
            //EnterText(By.CssSelector(".cart-vat__number input[type=text]"), GetUserData("vatNumber"));
            //ClickElement(By.CssSelector(".cart-vat__button"));

            //// Согласие с условиями
            //ClickElement(By.CssSelector(".cart-agreement__checkbox--first"));
            //ClickElement(By.CssSelector(".cart-agreement__checkbox--second > .n-checkbox-box-wrapper"));

            //// Нажатие на кнопку оплаты
            //ClickElement(By.CssSelector(".cart__payment-submit"));

            //// Ожидание страницы оплаты
            //driver.SwitchTo().Window(driver.WindowHandles[1]);
            //wait.Until(d => d.Url.Contains("demo.ipsp.lv"));

            //// Загрузка профиля платежных данных
            //LoadPaymentProfile();

            //// Получаем данные карты из профиля платежей
            //var card = paymentProfiles["cardLatvianBank"];

            //// Заполнение данных карты
            //SelectDropdown(By.CssSelector(".expire-wrapper > div:first-of-type select"), "10");
            //EnterText(By.CssSelector(".cardname"), card["name"].ToString());
            //EnterText(By.CssSelector(".cardnumber"), card["number"].ToString());
            //SelectDropdown(By.CssSelector(".expire-wrapper > div:last-of-type select"), "2030");
            //EnterText(By.CssSelector(".csc"), card["cvc"].ToString());

            //// Подтверждение платежа
            //ClickElement(By.CssSelector("input[type='submit']"));
            //ConfirmOTP();
        }

    }
}
