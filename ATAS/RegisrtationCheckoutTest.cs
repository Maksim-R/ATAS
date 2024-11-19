using NUnit.Framework;
using OpenQA.Selenium;
using ATAS.Tests;
using SeleniumExtras.WaitHelpers;
using ATAS.Test;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

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

            System.Threading.Thread.Sleep(3000);

            // Ввод email
            EnterText(By.CssSelector(".cart-contacts__form-email input[type=text]"), email);

            System.Threading.Thread.Sleep(3000);
            // Ввод кода страны            
            EnterText(By.CssSelector(".n-base-selection-input"), GetUserData("phoneCode") + Keys.Enter);

            System.Threading.Thread.Sleep(3000);

            // Заполнение контактных данных
            EnterText(By.CssSelector(".cart-contacts__form-number input[type=text]"), GetUserData("phone"));
            EnterText(By.CssSelector(".cart-individual__name input[type=text]"), GetUserData("name"));
            EnterText(By.CssSelector(".cart-individual__surname input[type=text]"), GetUserData("surname"));
            EnterText(By.CssSelector(".cart-individual__birth-date input[type=text]"), GetUserData("birthDate"));
            System.Threading.Thread.Sleep(2000);

            // Заполнение адресных данных           
            SelectDropdown(By.CssSelector(".cart-address__form-country .n-base-selection-input"), GetUserData("country"));
            EnterText(By.CssSelector(".cart-address__form-country"), GetUserData("country") + Keys.Enter);
            EnterText(By.CssSelector(".cart-address__form-city input[type=text]"), GetUserData("city"));
            EnterText(By.CssSelector(".cart-address__form-zip input[type=text]"), GetUserData("zip"));
            EnterText(By.CssSelector(".cart-address__form-address input[type=text]"), GetUserData("address"));
            System.Threading.Thread.Sleep(2000);

            // НДС
            ClickElement(By.CssSelector(".cart-vat__approval"));
            EnterText(By.CssSelector(".cart-vat__number input[type=text]"), GetUserData("vatNumber"));
            ClickElement(By.CssSelector(".cart-vat__button"));

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
