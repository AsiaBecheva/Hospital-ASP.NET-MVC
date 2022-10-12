namespace Hospital.Tests
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class HospitalFormValidationShould
    {
        private const string HomeUrl = "http://localhost:55925/";
        private const string RegisterUrl = "http://localhost:55925/Account/Register";

        [Fact]
        [Trait("Category", "Form")]
        public void CheckEmailSymbols()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                int minSymbolsEmail = 13;

                driver.Navigate().GoToUrl(RegisterUrl);

                driver.FindElement(By.Id("Email")).SendKeys("agdgajdaj@gmail.com");
                driver.FindElement(By.Id("Password")).SendKeys("assdadsadsasd");
                driver.FindElement(By.Id("ConfirmPassword")).SendKeys("assdadsadsasd");
                DemoHelper.Pause();
                driver.FindElement(By.Id("RegisterSubmit")).Click();

                string typedEmail = driver.FindElement(By.Id("Email")).GetAttribute("value");
                var sizeEmail = typedEmail.Length;

                if (sizeEmail < minSymbolsEmail)
                {
                    Assert.Fail("The symbols must be at least 13");
                }
            }
        }

        [Fact]
        [Trait("Category", "Form")]
        public void CheckRegistrationRedirect()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(RegisterUrl);
                driver.FindElement(By.Id("Email")).SendKeys("asiabecssh@gmail.com");
                DemoHelper.Pause();
                driver.FindElement(By.Id("Password")).SendKeys("AsdAsd");
                DemoHelper.Pause();
                driver.FindElement(By.Id("ConfirmPassword")).SendKeys("AsdAsd");
                DemoHelper.Pause();
                driver.FindElement(By.Id("RegisterSubmit")).Click();
                DemoHelper.Pause();

                Assert.Equal(HomeUrl, driver.Url);
            }
        }
    }
}
