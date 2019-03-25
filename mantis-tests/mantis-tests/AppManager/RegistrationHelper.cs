using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantistests
{
    public class RegistrationHelper : HelperBase
    {

        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            //var timeout = TimeSpan.FromSeconds(10);
            //WebDriverWait wait = new WebDriverWait(driver, timeout);
            //wait.Until(ExpectedConditions.ElementExists(By.CssSelector("back-to-login-link pull-left")));

            driver.FindElement(By.XPath("//div[@class = 'toolbar center']/a")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@class = 'width-40 pull-right btn btn-success btn-inverse bigger-110']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);

        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.20.0/login_page.php";
        }
    }
}
